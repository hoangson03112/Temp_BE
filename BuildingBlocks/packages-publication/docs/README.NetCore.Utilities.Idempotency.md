# NetCore.Utilities.Idempotency

`NetCore.Utilities.Idempotency` là middleware ASP.NET Core dùng Redis của `NetCore.Utilities.Memcache` để thực hiện idempotency cho request ghi dữ liệu. Middleware dùng header `Idempotency-Key`, **không** dùng `X-Correlation-Id` làm khóa nghiệp vụ.

## Cơ chế

Với `POST`, `PUT`, `PATCH`, middleware:

1. Bắt buộc `Idempotency-Key` dài 8-128 ký tự URL-safe.
2. Hash key Redis theo scope client/tenant, method, route và idempotency key; raw key không xuất hiện trong Redis key.
3. Hash method, route, query, content type và body để phát hiện cùng key nhưng payload khác.
4. Claim atomically bằng Redis `SET NX` với state `processing`.
5. Request trùng đang chạy trả `409` kèm `Retry-After: 1`; request trùng với body khác cũng trả `409`.
6. Sau khi request hoàn tất, lưu status, content type, `Location` và response body; retry cùng key sẽ replay đúng response và có header `Idempotency-Replayed: true`.
7. Chuyển `processing → completed` bằng compare-and-set Lua script để owner cũ không ghi đè claim mới khi lease không còn hợp lệ.

Redis là dependency bắt buộc. Nếu Redis không sẵn sàng, middleware fail closed: request không được chạy để tránh thực hiện side effect mà không có idempotency record.

## Cài đặt và tích hợp

```csharp
using NetCore.Utilities.Idempotency;
using NetCore.Utilities.Memcache;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký IConnectionMultiplexer, IRedisCacheClient và các dịch vụ Memcache.
builder.UseMemcache();

// Bind section Idempotency và validate cấu hình khi app khởi động.
builder.Services.AddRedisIdempotency(builder.Configuration, options =>
{
    // Bắt buộc cấu hình ở API nhiều tenant/client để cùng key không va chạm scope.
    options.ScopeResolver = httpContext =>
        httpContext.User.FindFirst("client_id")?.Value
        ?? throw new InvalidOperationException("client_id is required for idempotency scope.");
});

var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseAuthentication();
app.UseAuthorization();

// Đặt trước endpoints và trước middleware đọc body request.
app.UseRedisIdempotency();

app.MapControllers();
app.Run();
```

Ví dụ request:

```http
POST /api/payments HTTP/1.1
Content-Type: application/json
Idempotency-Key: 01J8Y2Q6BCB9X7KQRQH7R8S2V1

{"invoiceId":"INV-2026-0001","amount":500000}
```

## appsettings.json

`UseMemcache()` dùng cấu hình Redis hiện có của `NetCore.Utilities.Memcache`. Không đặt password Redis vào tài liệu source control.

```json
{
  "Redis": {
    "Configuration": "redis-01.internal:6379",
    "InstanceName": "payment-api"
  },
  "RedisCache": {
    "KeyPrefix": "payment-api",
    "OperationTimeout": "00:00:03",
    "RetryCount": 2
  },
  "Idempotency": {
    "HeaderName": "Idempotency-Key",
    "RedisKeyPrefix": "idempotency:v1",
    "CompletedRecordTtl": "1.00:00:00",
    "ProcessingRecordTtl": "00:15:00",
    "MaxKeyLength": 128,
    "MaxRequestBodyBytes": 1048576,
    "MaxResponseBodyBytes": 1048576
  }
}
```

## Response behavior

| Tình huống | Kết quả |
| --- | --- |
| Thiếu/sai `Idempotency-Key` | `400 application/problem+json` |
| Key đã dùng với request fingerprint khác | `409 application/problem+json` |
| Key đang `processing` | `409 application/problem+json`, `Retry-After: 1` |
| Key đã hoàn tất | Replay status/body trước đó, `Idempotency-Replayed: true` |
| Redis lỗi/timeout | Fail closed; exception đi theo exception handling của API, không chạy endpoint |

## Giới hạn vận hành

- `ProcessingRecordTtl` phải lớn hơn thời gian xử lý tối đa của endpoint. Nếu lease hết hạn trước khi endpoint trả response, middleware không chấp nhận ghi completion và trả lỗi thay vì cho phép silently replay sai state.
- Response phải không vượt `MaxResponseBodyBytes`; chỉ nên bật idempotency cho endpoint JSON có response giới hạn. Download/streaming/file response nên loại khỏi middleware hoặc có thiết kế storage riêng.
- Middleware không làm transaction giữa Redis và database/downstream. Với luồng thanh toán/ký số có side effect ngoài DB, vẫn cần outbox/saga hoặc idempotency contract tại downstream để xử lý crash giữa commit nghiệp vụ và response Redis.
- Không log raw `Idempotency-Key`, request body, token, PIN, private key, certificate hoặc payload ký số. Correlation ID chỉ phục vụ trace và vẫn nên được giữ độc lập.

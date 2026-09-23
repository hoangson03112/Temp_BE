# NetCore.Utilities.Logging

`NetCore.Utilities.Logging` cung cấp cấu hình Serilog JSON cho ASP.NET Core và middleware correlation logging. Package phù hợp để chuẩn hóa log console dạng JSON, liên kết log của một HTTP request và trả lại mã correlation cho client.

Package **không** tự triển khai tracing phân tán hoàn chỉnh, propagation header tới downstream hay idempotency cho API ghi dữ liệu.

---

## 1. Thành phần

| Thành phần | Mục đích |
| --- | --- |
| `AddSerilogJsonLogging()` | Cấu hình Serilog từ `IConfiguration`, enrich log bằng context, máy chủ, môi trường, process, thread, `Application`, `Environment`; ghi console theo Compact JSON. |
| `UseCorrelationLogging()` | Đăng ký `CorrelationMiddleware`. Middleware nhận/tạo `X-Correlation-Id`, trả header này trong response và thêm dữ liệu request vào `LogContext`. |
| `CorrelationMiddleware` | Công khai hằng `CorrelationHeaderName = "X-Correlation-Id"`. Nếu request không có header hợp lệ theo kiểm tra hiện tại (rỗng/trắng), sinh `Guid.NewGuid().ToString("N")`. |
| `SeverityEnricher` | Chuyển Serilog level thành field `severity`: `CRITICAL`, `ERROR`, `WARNING`, `INFO`, `DEBUG`, `TRACE`. Class này không được `AddSerilogJsonLogging()` đăng ký tự động. |

## 2. Cài đặt

```bash
dotnet add package NetCore.Utilities.Logging
```

Package hiện target `net8.0` và tham chiếu Serilog ASP.NET Core, Compact JSON formatter cùng các enrichers Environment, Process và Thread.

## 3. Tích hợp tối thiểu

Trong `Program.cs`, cấu hình Serilog trước khi tạo application, sau đó đặt correlation middleware trước endpoint/business middleware cần log.

```csharp
using NetCore.Utilities.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogJsonLogging();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCorrelationLogging();
app.MapControllers();

app.Run();
```

Ví dụ request/response:

```http
GET /api/health HTTP/1.1
Host: api.example.internal
X-Correlation-Id: 3f8b09f07d794a22ba0ca7797b6bb539
```

```http
HTTP/1.1 200 OK
X-Correlation-Id: 3f8b09f07d794a22ba0ca7797b6bb539
```

Nếu client không gửi `X-Correlation-Id`, middleware sinh UUID dạng `N` (32 ký tự hex, không có dấu gạch nối) và trả giá trị đó trong response. Giá trị client gửi hiện được tin dùng nguyên trạng nếu không rỗng/trắng.

## 4. Nội dung log

Khi `UseCorrelationLogging()` bao bọc request, mọi Serilog event được ghi trong scope sẽ có các property sau, nếu sink/formatter giữ property từ log context:

| Property | Nguồn |
| --- | --- |
| `CorrelationId` | Header `X-Correlation-Id` hoặc UUID middleware sinh. |
| `TraceId`, `SpanId` | `Activity.Current`; có thể null nếu chưa có `Activity`. |
| `RequestPath`, `RequestMethod` | HTTP request hiện tại. |
| `ClientIp` | `HttpContext.Connection.RemoteIpAddress`; sau reverse proxy cần cấu hình forwarded headers đúng cách. |
| `Application`, `Environment` | ASP.NET Core hosting environment. |
| Machine/process/thread | Các Serilog enricher tương ứng. |

`AddSerilogJsonLogging()` đọc section `Serilog` trong cấu hình, áp dụng `MinimumLevel.Override` cho `Microsoft` và `System` là `Warning`, sau đó luôn ghi Compact JSON ra console.

Ví dụ cấu hình mức log:

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    }
  }
}
```

## 5. Severity enricher (tùy chọn)

`SeverityEnricher` có trong package nhưng chưa được extension mặc định thêm vào `LoggerConfiguration`. Nếu cần field `severity`, ứng dụng phải đăng ký nó khi cấu hình Serilog, ví dụ trong callback `UseSerilog` riêng của ứng dụng:

```csharp
using NetCore.Utilities.Logging;
using Serilog;

builder.Host.UseSerilog((context, services, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .Enrich.With<SeverityEnricher>());
```

Không gọi đồng thời đoạn cấu hình riêng này và `AddSerilogJsonLogging()` nếu cả hai cùng thiết lập logger toàn cục mà chưa chủ động gộp cấu hình; chọn một nơi cấu hình `UseSerilog` để tránh nhầm lẫn thứ tự/sink.

## 6. Correlation ID và idempotency

### Kết luận kiểm tra hiện trạng

`X-Correlation-Id` **không đáp ứng chuẩn/cơ chế idempotency** trong implementation hiện tại.

Lý do kiểm chứng trực tiếp từ `CorrelationMiddleware`:

1. Header chỉ được đọc hoặc sinh mới, gắn vào response và Serilog `LogContext`.
2. Không có kho lưu trữ theo key, TTL, unique index hoặc transaction/claim để phát hiện request trùng.
3. Không có request fingerprint để phát hiện cùng key nhưng payload khác nhau.
4. Không có cơ chế giữ request đang chạy, cache/replay HTTP status-body, hay quy tắc retry.
5. Header do client cung cấp không bị giới hạn độ dài/định dạng và một correlation ID có thể được dùng cho nhiều operation khác nhau.

Vì vậy correlation ID dùng cho **truy vết và liên kết log**, không được dùng làm khóa chống tạo dữ liệu trùng, chống thanh toán/ký số lặp hoặc điều kiện retry `POST`.

### Khuyến nghị contract idempotency

Với endpoint có side effect, dùng header riêng, ví dụ:

```http
Idempotency-Key: 01J8Y2Q6BCB9X7KQRQH7R8S2V1
```

Server cần tối thiểu:

1. Bắt buộc key cho operation cần bảo vệ; đặt giới hạn độ dài, charset và scope theo tenant/client + HTTP method + route.
2. Trong cùng transaction, insert/claim `(tenant, operation, idempotency_key)` vào bảng có unique constraint.
3. Lưu hash canonical của request. Nếu key đã tồn tại nhưng hash khác, trả `409 Conflict` (hoặc lỗi contract tương đương), không chạy operation mới.
4. Nếu operation hoàn tất, lưu HTTP status và response an toàn để retry cùng key nhận lại cùng kết quả.
5. Nếu operation đang xử lý, trả trạng thái đang xử lý phù hợp (`409`/`425`/`202` theo contract) thay vì chạy song song.
6. Đặt TTL/retention theo nghiệp vụ; chỉ xóa record sau khi hết cửa sổ retry và yêu cầu audit.

Ví dụ Oracle tối thiểu (chỉ là mẫu thiết kế, không phải migration được package tạo sẵn):

```sql
CREATE TABLE API_IDEMPOTENCY (
    TENANT_ID        VARCHAR2(100) NOT NULL,
    OPERATION        VARCHAR2(150) NOT NULL,
    IDEMPOTENCY_KEY  VARCHAR2(128) NOT NULL,
    REQUEST_HASH     VARCHAR2(64)  NOT NULL,
    STATUS           VARCHAR2(20)  NOT NULL,
    RESPONSE_STATUS  NUMBER(3),
    RESPONSE_BODY    CLOB,
    CREATED_AT       TIMESTAMP     NOT NULL,
    EXPIRES_AT       TIMESTAMP     NOT NULL,
    CONSTRAINT PK_API_IDEMPOTENCY PRIMARY KEY
        (TENANT_ID, OPERATION, IDEMPOTENCY_KEY)
);
```

`X-Correlation-Id` vẫn nên được giữ để trace xuyên service. Ghi cả `CorrelationId` và idempotency key đã được che/masked (hoặc hash) trong log; không ghi request body, token, chữ ký số hay dữ liệu nhạy cảm.

## 7. Giới hạn cần lưu ý

- Middleware hiện không tự propagate `X-Correlation-Id` đến `HttpClient`/downstream service. Cần delegating handler hoặc OpenTelemetry propagation riêng nếu muốn xuyên chuỗi dịch vụ.
- Không tin `ClientIp` khi chạy sau proxy nếu chưa bật/cấu hình `ForwardedHeadersMiddleware` với proxy/network tin cậy.
- Correlation ID từ client hiện chưa được validate; nếu expose public API, nên bổ sung giới hạn kích thước và danh sách ký tự cho mục đích chống log injection/field quá lớn.
- Không log credentials, access token, PIN, private key, certificate, payload ký số hoặc response chứa dữ liệu nhạy cảm.

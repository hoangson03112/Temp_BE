# NetCore.Utilities.Memcache

Thư viện hỗ trợ cache Redis cho .NET theo hướng dùng thực tế trong hệ thống enterprise, bao gồm:

- Tích hợp `IDistributedCache`
- Raw Redis qua `IConnectionMultiplexer`
- Lấy TTL của key
- Timeout cho Redis operation
- Retry cho lỗi transient
- Distributed lock chống cache stampede
- Metrics Prometheus
- Key prefix builder
- API `GetOrCreateAsync<T>` tiện dùng

Thư viện phù hợp cho các hệ thống .NET cần cache dữ liệu ứng dụng, cấu hình, danh mục, OTP, session tạm thời hoặc các dữ liệu đọc nhiều.

---

## 1. Tính năng chính

- Đăng ký nhanh bằng `AddMemcache(...)`
- Dùng `ICacheService` để thao tác cache
- Hỗ trợ `CancellationToken`
- Hỗ trợ đọc giá trị kèm thời gian hết hạn còn lại
- Hỗ trợ cập nhật dữ liệu mà giữ nguyên TTL cũ
- Hỗ trợ build key theo prefix chuẩn
- Hỗ trợ `GetOrCreateAsync<T>` có lock Redis để tránh nhiều luồng cùng rebuild cache
- Có metrics Prometheus để theo dõi operation, retry, lock

---

## 2. Package dependencies

```xml
<PackageReference Include="Microsoft.Extensions.Caching.StackExchangeRedis" Version="8.0.8" />
<PackageReference Include="StackExchange.Redis" Version="2.8.31" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
<PackageReference Include="prometheus-net" Version="8.2.1" />
```

---

## 3. Cấu hình appsettings.json

### 3.1 Cấu hình Redis

```json
{
  "Redis": {
    "Configuration": "127.0.0.1:6379",
    "Password": "encrypted-password",
    "InstanceName": "myapp"
  },
  "RedisCache": {
    "KeyPrefix": "myapp",
    "OperationTimeout": "00:00:03",
    "RetryCount": 2,
    "RetryBaseDelay": "00:00:00.150",
    "LockExpiry": "00:00:30",
    "LockWaitTimeout": "00:00:10",
    "LockRetryDelay": "00:00:00.200",
    "EnableVerboseLogging": false
  }
}
```

### 3.2 Ý nghĩa cấu hình

`Redis`
- `Configuration`: địa chỉ Redis, ví dụ `127.0.0.1:6379` hoặc nhiều node
- `Password`: mật khẩu Redis, có thể lưu dạng mã hóa rồi giải mã bằng `Decrypt()`
- `InstanceName`: prefix logic của ứng dụng, được dùng fallback cho `KeyPrefix` nếu chưa cấu hình riêng
`RedisCache`
- `KeyPrefix`: prefix chung cho toàn bộ cache key
- `OperationTimeout`: timeout cho mỗi Redis operation
- `RetryCount`: số lần retry thêm sau lần đầu
- `RetryBaseDelay`: delay gốc giữa các lần retry
- `LockExpiry`: TTL của distributed lock
- `LockWaitTimeout`: thời gian chờ tối đa để lấy lock
- `LockRetryDelay`: delay giữa các lần thử lấy lock
- `EnableVerboseLogging`: bật log chi tiết khi retry thành công hoặc debug thêm

---

## 4. Đăng ký Dependency Injection

Trong `Program.cs`:

```C#
builder.Services.AddMemcache(builder.Configuration);
```

Hoặc trong `Startup.cs`:

```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMemcache(Configuration);
}
```

---

## 5. Interface chính

Thư viện expose interface chính:

```C#
ICacheService
```

Các khả năng chính:

- Set / Get cache
- Get cache kèm TTL
- Kiểm tra key tồn tại
- Xóa key
- Update cache giữ nguyên TTL
- `GetOrCreateAsync<T>`
- Build key theo segments

---

## 6. Cách dùng cơ bản

### 6.1 Inject service

```C#
using NetCore.Utilities.Memcache.Services;

public class UserService
{
    private readonly ICacheService _cacheService;

    public UserService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }
}
```

---

## 7. Ví dụ sử dụng

### 7.1 Build key

```C#
var key = _cacheService.BuildKey("user-profile", userId.ToString());
```

Kết quả ví dụ:

```
myapp:user-profile:12345
```

---
### 7.2 Set cache

```C#
await _cacheService.SetCacheAsync(
    key,
    userDto,
    TimeSpan.FromMinutes(10),
    ct);
```

---
### 7.3 Get cache object

```C#
var user = await _cacheService.GetCacheAsync<UserDto>(key, ct);
if (user == null)
{
    // cache miss
}
```

---
### 7.4 Get cache dạng `JObject`

```C#
var data = await _cacheService.GetCacheAsync(key, ct);
if (data != null)
{
    var name = data["name"]?.ToString();
}
```

---
### 7.5 Get cache kèm TTL

#### Lấy string + expiry

```C#
var (value, ttl) = await _cacheService.GetStringWithExpiryAsync(key, ct);
```

#### Lấy object + expiry

```C#
var (user, ttl) = await _cacheService.GetCacheWithExpiryAsync<UserDto>(key, ct);
```

---
### 7.6 Update cache nhưng giữ nguyên TTL cũ

```C#
await _cacheService.UpdateCacheAsync(key, updatedUserDto, ct);
```

Lưu ý:

- Nếu key không tồn tại hoặc không còn TTL hợp lệ, service sẽ ném exception.

---
### 7.7 Kiểm tra key tồn tại

```C#
var exists = await _cacheService.KeyExistsAsync(key, ct);
```
---
### 7.8 Xóa key

```C#
await _cacheService.RemoveKeyAsync(key, ct);
```

---

## 8. `GetOrCreateAsync<T>` chống cache stampede

Đây là API quan trọng nhất khi cache dữ liệu đọc nhiều từ DB hoặc service ngoài.

### 8.1 Dùng với key string

```C#
var key = _cacheService.BuildKey("dm-donvi", maDonVi);

var result = await _cacheService.GetOrCreateAsync(
    key,
    async token =>
    {
        return await _repository.GetDonViAsync(maDonVi, token);
    },
    TimeSpan.FromMinutes(30),
    ct);
```

### 8.2 Dùng với key segments

```C#
var result = await _cacheService.GetOrCreateAsync(
    new[] { "dm-donvi", maDonVi },
    async token =>
    {
        return await _repository.GetDonViAsync(maDonVi, token);
    },
    TimeSpan.FromMinutes(30),
    ct);
```

### 8.3 Cách hoạt động

1. Đọc cache trước
2. Nếu cache miss, lấy distributed lock Redis
3. Sau khi lấy lock, đọc cache lần nữa
4. Nếu vẫn miss, gọi `factory(...)` để sinh dữ liệu
5. Ghi lại cache
6. Thả lock

Cách này giúp tránh nhiều request cùng lúc cùng gọi DB khi cache vừa hết hạn.

---

## 9. Metrics Prometheus

Thư viện sinh ra các metric sau:

### 9.1 Redis operation

- `redis_cache_operation_total`
- `redis_cache_operation_duration_seconds`
- `redis_cache_operation_in_progress`
- `redis_cache_retry_total`

### 9.2 Redis distributed lock

- `redis_cache_lock_total`

### 9.3 Label sử dụng

`redis_cache_operation_total`
- `operation`
- `status`

Ví dụ:

- `operation="string_get"`
- `status="success"`

`redis_cache_lock_total`
- `action`
- `status`

Ví dụ:

- `action="acquire"`
- `status="success"`

### 9.4 Lưu ý cardinality

Thư viện **không** gắn label theo cache key thực tế để tránh làm nổ cardinality trong Prometheus.

---

## 10. Timeout và retry
### 10.1 Timeout

Các operation Redis raw được bọc thêm timeout logic ở tầng policy.

Điều này giúp:

- request không bị treo quá lâu
- caller có thể cancel bằng `CancellationToken`

Lưu ý:

- `StackExchange.Redis` không hỗ trợ cancel native cho toàn bộ command async theo kiểu truyền `CancellationToken` trực tiếp.
- Thư viện áp timeout/cancel ở tầng `await`.

### 10.2 Retry

Retry chỉ áp cho các lỗi được xem là transient, ví dụ:

- `RedisConnectionException`
- `RedisTimeoutException`
- `RedisServerException`
- `TimeoutException`

Các lỗi non-transient sẽ ném ra ngay.

---

## 11. Key prefix strategy
Thư viện hỗ trợ prefix qua `RedisCacheOptions.KeyPrefix`.

Ví dụ:

```json
"RedisCache": {
  "KeyPrefix": "myapp"
}
```

Khi build key:

```C#
var key = _cacheService.BuildKey("users", "123");
```

Kết quả:

```
myapp:users:123
```

**Khuyến nghị**

Nên chuẩn hóa key theo dạng:

```
{module}:{entity}:{id}
```

Ví dụ:

```
myapp:user-profile:10001
myapp:otp:84999999999
myapp:dm-donvi:01001
```

---

## 12. Lifetime trong DI

Mặc định:

- `IConnectionMultiplexer`: `Singleton`
- `IRedisExecutionPolicy`: `Singleton`
- `ICacheKeyBuilder`: `Singleton`
- `IRedisCacheClient`: `Singleton`
- `IRedisDistributedLock`: `Singleton`
- `ICacheService`: `Scoped`

Lý do:

- Redis connection nên dùng singleton
- policy, key builder, client, lock không giữ state request-specific
- cache service có thể để scoped để đồng bộ với service application

---

## 13. Exception có thể gặp

`RedisOperationTimeoutException`

Ném ra khi Redis operation vượt quá `OperationTimeout`.

`TimeoutException`

Có thể ném ra khi không lấy được distributed lock trong thời gian cho phép.

`KeyNotFoundException`

Có thể ném ra khi gọi `UpdateCacheAsync(...)` nhưng key không còn TTL hoặc không tồn tại.

`ArgumentException`

Ném ra khi key rỗng hoặc segments không hợp lệ.

---

## 14. Best practices

**Nên dùng `BuildKey(...)`**

Không nên tự nối chuỗi key lung tung ở nhiều chỗ.

**Dùng `GetOrCreateAsync(...)` cho dữ liệu tra cứu nhiều**

Phù hợp với:

- danh mục
- thông tin người dùng
- cấu hình
- dữ liệu lấy từ DB/service ngoài nhưng ít thay đổi

**Không cache dữ liệu quá lớn nếu không cần**

Redis nhanh nhưng RAM đắt.

**Không gắn key vào label metric**

Tránh cardinality quá lớn.

**Với dữ liệu quan trọng, chọn TTL hợp lý**

Không nên để quá ngắn gây rebuild liên tục, cũng không nên quá dài nếu dữ liệu thay đổi thường xuyên.

---

## 15. Ví dụ service thực tế

```C#
using NetCore.Utilities.Memcache.Services;

public class DonViService
{
    private readonly ICacheService _cacheService;
    private readonly IDonViRepository _repository;

    public DonViService(
        ICacheService cacheService,
        IDonViRepository repository)
    {
        _cacheService = cacheService;
        _repository = repository;
    }

    public async Task<DonViDto?> GetDonViAsync(string maDonVi, CancellationToken ct = default)
    {
        return await _cacheService.GetOrCreateAsync(
            new[] { "dm-donvi", maDonVi },
            async token =>
            {
                return await _repository.GetByMaAsync(maDonVi, token);
            },
            TimeSpan.FromMinutes(30),
            ct);
    }
}
```

---

## 16. Ví dụ controller

```C#
[ApiController]
[Route("api/cache-demo")]
public class CacheDemoController : ControllerBase
{
    private readonly ICacheService _cacheService;

    public CacheDemoController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id, CancellationToken ct)
    {
        var key = _cacheService.BuildKey("demo", id);

        var result = await _cacheService.GetOrCreateAsync(
            key,
            async token =>
            {
                await Task.Delay(100, token);
                return new
                {
                    Id = id,
                    Name = "Demo",
                    CreatedAt = DateTime.UtcNow
                };
            },
            TimeSpan.FromMinutes(5),
            ct);

        return Ok(result);
    }
}
```

---

## 17. Yêu cầu hạ tầng

- Redis server hoạt động ổn định
- Ứng dụng có thể kết nối Redis qua network
- Nếu dùng password mã hóa trong config thì phải có extension `Decrypt()` tương ứng trong solution

---

## 18. Hạn chế hiện tại

- `StackExchange.Redis` không cancel command async native hoàn toàn theo `CancellationToken`
- Lock hiện tại dùng Redis single-instance pattern thông qua `LockTakeAsync`
- Nếu hệ thống cần distributed lock mạnh hơn trên multi-master phức tạp, cần cân nhắc chiến lược lock riêng

---

## 19. Namespace chính

```C#
using NetCore.Utilities.Memcache;
using NetCore.Utilities.Memcache.Services;
```

---

## 20. Ghi chú triển khai

- Không dùng `BuildServiceProvider()` bên trong extension DI
- `IConnectionMultiplexer` được đăng ký singleton
- `InstanceName` của `StackExchangeRedisCache` được để `null` để tránh prefix 2 lần
- `KeyPrefix` được quản lý tập trung ở `RedisCacheOptions`

---

## 21. Tóm tắt

`NetCore.Utilities.Memcache` giúp chuẩn hóa việc dùng Redis cache trong .NET theo hướng:

- dễ dùng
- có timeout
- có retry
- có lock
- có metrics
- phù hợp môi trường production

Package này đặc biệt hữu ích khi cần giảm tải DB, tránh cache stampede và theo dõi hiệu năng cache bằng Prometheus.

---

## 22. License / Internal usage

Thư viện này phù hợp cho sử dụng nội bộ hoặc đóng gói thành NuGet private feed trong hệ thống `NetCore.*`.

Nếu dùng cho private package, nên version hóa theo semantic versioning:

```
1.0.0
1.1.0
1.2.0
```


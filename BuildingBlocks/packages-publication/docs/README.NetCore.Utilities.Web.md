# NetCore.Utilities.Web

`NetCore.Utilities.Web` là phần mở rộng Web/HTTP thuộc bộ thư viện `NetCore.Utilities`.

Package cung cấp:

- Helpers xử lý URL/path/query string (`WebUtilities`).
- HTTP client dùng DI (`IDefaultHttpClientService`, `DefaultHttpClientService`) cho JSON/Form/SOAP.
- `IHttpClientFactory` + named clients cho `default-json`, `soap`, `form`, `long-running`.
- Retry/timeout/circuit breaker bằng Polly.
- Metrics cho outgoing HTTP.
- OpenTelemetry tracing cho ASP.NET Core + HttpClient.
- Correlation logging bằng Serilog JSON, phù hợp Fluent Bit.
- Exception & ActionResult tiện cho WebAPI (`HttpException`, `HttpResponseException`, `StatusCodeObjectResult`).
- Constant sẵn dùng: `MimeTypeNames`, `JwtClaimTypes`.
- Utilities khác: `WeakCollection<T>`, `ValidatorModel`, extensions cho Claims.

---

## Cài đặt

```bash
# NuGet
dotnet add package NetCore.Utilities.Web.Core
```

Các package thường dùng kèm nếu project bật Polly, OpenTelemetry và Serilog:

```bash
dotnet add package Microsoft.Extensions.Http.Polly
dotnet add package Polly.Extensions.Http

dotnet add package OpenTelemetry.Extensions.Hosting
dotnet add package OpenTelemetry.Instrumentation.AspNetCore
dotnet add package OpenTelemetry.Instrumentation.Http
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol

dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Formatting.Compact
dotnet add package Serilog.Enrichers.Environment
dotnet add package Serilog.Enrichers.Process
dotnet add package Serilog.Enrichers.Thread
```

---

## Quick start

### 1) URL helpers

```csharp
using NetCore.Utilities.Web;

var url = "api/v1/items".EnsureLeadingSlash();        // "/api/v1/items"
var origin = "https://example.com/a/b".GetOrigin();   // "https://example.com"
```

### 2) Đọc query string

```csharp
var nv = "https://a.com/callback?code=123&state=xyz"
    .ReadQueryStringAsNameValueCollection();

var code = nv["code"]; // "123"
```

### 3) Đăng ký HTTP client service

```csharp
using NetCore.Utilities.Http;
using NetCore.Utilities.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogJsonLogging();

builder.Services.AddDefaultHttpClientService(builder.Configuration);

builder.Services.AddOpenTelemetryObservability(
    builder.Configuration,
    serviceName: "tnhs-api",
    serviceVersion: "1.0.0");

var app = builder.Build();

app.UseCorrelationLogging();

app.Run();
```

### 4) Gọi HTTP JSON

```csharp
using NetCore.Utilities.Http;

public sealed class UserService
{
    private readonly IDefaultHttpClientService _http;

    public UserService(IDefaultHttpClientService http)
    {
        _http = http;
    }

    public Task<CreateUserResponse> CreateUserAsync(
        CreateUserRequest request,
        CancellationToken ct)
    {
        return _http.PostAsync<CreateUserRequest, CreateUserResponse>(
            request,
            "https://api.example.com/users",
            ct: ct);
    }
}
```

---

## Cấu hình

### `appsettings.json`

```json
{
  "SharedHttpClient": {
    "DefaultJson": {
      "TimeoutSeconds": 30,
      "RetryCount": 2,
      "CircuitBreakerHandledEventsAllowedBeforeBreaking": 5,
      "CircuitBreakerDurationOfBreakSeconds": 30,
      "EnableCircuitBreaker": true
    },
    "Soap": {
      "TimeoutSeconds": 60,
      "RetryCount": 1,
      "CircuitBreakerHandledEventsAllowedBeforeBreaking": 3,
      "CircuitBreakerDurationOfBreakSeconds": 60,
      "EnableCircuitBreaker": true
    },
    "Form": {
      "TimeoutSeconds": 60,
      "RetryCount": 1,
      "CircuitBreakerHandledEventsAllowedBeforeBreaking": 3,
      "CircuitBreakerDurationOfBreakSeconds": 30,
      "EnableCircuitBreaker": true
    },
    "LongRunning": {
      "TimeoutSeconds": 300,
      "RetryCount": 0,
      "CircuitBreakerHandledEventsAllowedBeforeBreaking": 0,
      "CircuitBreakerDurationOfBreakSeconds": 0,
      "EnableCircuitBreaker": false
    }
  },
  "OpenTelemetry": {
    "Otlp": {
      "Endpoint": "http://otel-collector:4317"
    }
  },
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "Properties": {
      "Service": "tnhs-api"
    }
  }
}
```

---

## HTTP Client usage

`IDefaultHttpClientService` là API chính để gọi HTTP. Không sử dụng extension static kiểu cũ.

### GET JSON

```csharp
var user = await _http.GetAsync<UserResponse>(
    "https://api.example.com/users/1",
    ct: ct);
```

### GET với query từ object

```csharp
var response = await _http.GetAsync<SearchUserRequest, SearchUserResponse>(
    new SearchUserRequest
    {
        Keyword = "admin",
        Page = 1,
        Size = 20
    },
    "https://api.example.com/users/search",
    ct: ct);
```

### POST JSON trả object

```csharp
var response = await _http.PostAsync<CreateUserRequest, CreateUserResponse>(
    request,
    "https://api.example.com/users",
    headers: new Dictionary<string, string>
    {
        ["Authorization"] = $"Bearer {accessToken}"
    },
    ct: ct);
```

### POST JSON trả string

```csharp
var responseText = await _http.PostStringAsync(
    request,
    "https://api.example.com/raw",
    ct: ct);
```

### POST không cần response body

```csharp
await _http.PostNoResponseAsync(
    request,
    "https://api.example.com/events",
    ct: ct);
```

### PUT JSON

```csharp
await _http.PutAsync(
    request,
    "https://api.example.com/users/1",
    ct: ct);
```

### Form URL encoded

```csharp
var token = await _http.PostFormAsync<TokenRequest, TokenResponse>(
    new TokenRequest
    {
        ClientId = "client-id",
        ClientSecret = "client-secret",
        GrantType = "client_credentials"
    },
    "https://auth.example.com/connect/token",
    ct: ct);
```

### Multipart form-data

```csharp
var response = await _http.PostDataFormAsync<UploadRequest, UploadResponse>(
    request,
    "https://api.example.com/upload",
    ct: ct);
```

### SOAP object envelope

```csharp
var namespaces = new Dictionary<string, string>
{
    ["soapenv"] = "http://schemas.xmlsoap.org/soap/envelope/",
    ["ns2"] = "http://teca.com/sms/generated/ws/ivan"
};

var response = await _http.PostSoapAsync<SoapEnvelope, SoapResponse>(
    envelope,
    "https://soap.example.com/service",
    namespaces,
    ct: ct);
```

### SOAP raw string

```csharp
var xml = await _http.PostSoapAsync(
    soap,
    "https://soap.example.com/service",
    ct: ct);
```

### SOAP `XmlDocument`

```csharp
var resultDoc = await _http.PostSoapAsync(
    doc,
    "https://soap.example.com/service",
    soapAction: "urn:submit",
    ct: ct);
```

---

## Gọi nhiều API trong cùng một luồng

Luồng nghiệp vụ nên nằm ở Application/Workflow service. `IDefaultHttpClientService` chỉ chịu trách nhiệm gọi HTTP.

```csharp
public sealed class ExportPdfWorkflowService
{
    private readonly IDefaultHttpClientService _http;
    private readonly ExportPdfOptions _options;

    public ExportPdfWorkflowService(
        IDefaultHttpClientService http,
        ExportPdfOptions options)
    {
        _http = http;
        _options = options;
    }

    public async Task<ExportPdfResult> ExecuteAsync(
        ExportPdfRequest request,
        CancellationToken ct)
    {
        var profile = await _http.PostAsync<ProfileRequest, ProfileResponse>(
            new ProfileRequest { UserId = request.UserId },
            _options.ProfileApiUrl,
            ct: ct);

        var token = await _http.PostFormAsync<TokenRequest, TokenResponse>(
            new TokenRequest
            {
                ClientId = _options.ClientId,
                ClientSecret = _options.ClientSecret,
                GrantType = "client_credentials"
            },
            _options.TokenUrl,
            ct: ct);

        var soapResponse = await _http.PostSoapAsync<SoapEnvelope, SoapResponse>(
            BuildEnvelope(profile),
            _options.SoapUrl,
            _options.SoapNamespaces,
            headers: new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {token.AccessToken}"
            },
            ct: ct);

        var render = await _http.PostAsync<RenderPdfRequest, RenderPdfResponse>(
            new RenderPdfRequest { Xml = soapResponse.Xml },
            _options.RenderPdfUrl,
            ct: ct);

        return new ExportPdfResult
        {
            FileBase64 = render.FileBase64
        };
    }
}
```

Nếu các API độc lập nhau, có thể gọi song song:

```csharp
var userTask = _http.GetAsync<UserResponse>(userUrl, ct: ct);
var categoryTask = _http.GetAsync<CategoryResponse>(categoryUrl, ct: ct);

await Task.WhenAll(userTask, categoryTask);

var user = await userTask;
var category = await categoryTask;
```

Chỉ gọi song song khi các API không phụ thuộc dữ liệu của nhau.

---

## Retry, timeout và circuit breaker

HTTP client được chia theo nhóm:

| Client kind | Mục đích | Retry mặc định | Timeout mặc định |
|---|---|---:|---:|
| `DefaultJson` | API JSON thông thường | 2 | 30s |
| `Soap` | SOAP/XML | 1 | 60s |
| `Form` | form-url-encoded, multipart | 1 | 60s |
| `LongRunning` | API chạy lâu | 0 | 300s |

Retry policy nên phân biệt method:

| Method | Retry |
|---|---|
| `GET`, `HEAD`, `OPTIONS` | Có thể retry |
| `PUT`, `DELETE` | Chỉ retry khi nghiệp vụ đảm bảo idempotent |
| `POST` | Không retry mặc định để tránh tạo dữ liệu trùng |

Nếu cần retry `POST`, hệ thống gọi ngoài nên hỗ trợ `Idempotency-Key`.

---

## Correlation logging

Middleware correlation sẽ tạo hoặc lấy `X-Correlation-Id` từ request đầu vào, sau đó đưa vào log scope.

Log JSON sẽ có các field:

```json
{
  "CorrelationId": "...",
  "TraceId": "...",
  "SpanId": "...",
  "RequestPath": "/api/hoso/process",
  "RequestMethod": "POST"
}
```

Khi gọi downstream API, HTTP client nên propagate:

```http
X-Correlation-Id: ...
traceparent: ...
trace-id: ...
span-id: ...
```

Không log token, password, raw certificate, full SOAP/XML/JSON chứa dữ liệu nhạy cảm.

---

## Serilog JSON cho Fluent Bit

Ứng dụng nên ghi log dạng JSON một dòng trên stdout.

### Program.cs

```csharp
builder.AddSerilogJsonLogging();
```

### Log business

```csharp
_logger.LogInformation(
    "Processing hồ sơ. HosoId={HosoId}, UnitCode={UnitCode}",
    hosoId,
    unitCode);
```

Không nên dùng string concatenation:

```csharp
// Không khuyến nghị
_logger.LogInformation("Processing hồ sơ " + hosoId);
```

### Fluent Bit parser mẫu

```ini
[SERVICE]
    Flush         1
    Daemon        Off
    Log_Level     info
    Parsers_File  parsers.conf

[INPUT]
    Name              tail
    Path              /var/log/containers/*.log
    Parser            docker
    Tag               kube.*
    Mem_Buf_Limit     50MB
    Skip_Long_Lines   On
    Refresh_Interval  5

[FILTER]
    Name                kubernetes
    Match               kube.*
    Merge_Log           On
    Keep_Log            Off
    K8S-Logging.Parser  On
    K8S-Logging.Exclude Off

[FILTER]
    Name          parser
    Match         kube.*
    Key_Name      log
    Parser        json

[OUTPUT]
    Name   stdout
    Match  *
```

### parsers.conf

```ini
[PARSER]
    Name        json
    Format      json
    Time_Key    @t
    Time_Format %Y-%m-%dT%H:%M:%S.%LZ
    Time_Keep   On
```

---

## OpenTelemetry

Đăng ký:

```csharp
builder.Services.AddOpenTelemetryObservability(
    builder.Configuration,
    serviceName: "tnhs-api",
    serviceVersion: "1.0.0");
```

Tracing mặc định gồm:

- ASP.NET Core incoming request.
- HttpClient outgoing request.
- Manual span từ `ActivitySource` nếu service có tạo thêm.

Metrics mặc định gồm:

| Metric | Ý nghĩa |
|---|---|
| `httpclient_outgoing_requests_total` | Tổng request outgoing |
| `httpclient_outgoing_requests_error_total` | Tổng lỗi outgoing |
| `httpclient_outgoing_request_duration_ms` | Thời gian xử lý outgoing |
| `httpclient_outgoing_requests_inflight` | Request outgoing đang xử lý |

---

## API Reference

### 1) `NetCore.Utilities.Web.WebUtilities`

Extension cho xử lý URL/path:

- `EnsureLeadingSlash(this string url)`
  - Đảm bảo path bắt đầu bằng `/`.
- `EnsureTrailingSlash(this string url)`
  - Đảm bảo path kết thúc bằng `/`.
- `RemoveLeadingSlash(this string url)`
  - Bỏ ký tự `/` ở đầu nếu có.
- `RemoveTrailingSlash(this string url)`
  - Bỏ ký tự `/` ở cuối nếu có.
- `CleanUrlPath(this string url)`
  - Chuẩn hóa path: null/empty → `/`, và bỏ `/` cuối trừ trường hợp chỉ có `/`.
- `IsLocalUrl(this string url)`
  - Kiểm tra url local, hỗ trợ `/...` và `~/...`, chặn `//` hoặc `/\`.
- `AddQueryString(this string url, string query)`
  - Thêm raw query string vào url, tự thêm `?`/`&`.
- `AddQueryString(this string url, string name, string value)`
  - Thêm query param và URL-encode value.
- `AddHashFragment(this string url, string query)`
  - Thêm fragment `#...`.
- `ReadQueryStringAsNameValueCollection(this string url)`
  - Parse query string → `NameValueCollection`.
- `GetOrigin(this string url)`
  - Lấy origin `scheme://host(:port)` cho http/https.

### 2) `NetCore.Utilities.Http.IDefaultHttpClientService`

Service chính để gọi HTTP:

- `PostJsonAsync(JObject entity, string url, Dictionary<string,string>? headers = null, ILogger? logger = null, long timeout = 300, CancellationToken ct = default) : Task<JObject>`
- `PostStringAsync<T>(T entity, string url, ...) : Task<string>`
- `PostAsync<TRequest,TResponse>(TRequest entity, string url, ...) : Task<TResponse>`
- `PostAsync<TRequest>(TRequest entity, string url, ...) : Task<bool>`
- `PostBoolAsync<TRequest,TResponse>(TRequest entity, string url, ...) : Task<TResponse>`
- `PostNoResponseAsync<T>(T entity, string url, ...) : Task`
- `PutAsync<TRequest,TResponse>(TRequest entity, string url, ...) : Task<TResponse>`
- `PutAsync<T>(T entity, string url, ...) : Task`
- `PostAsync<T>(T entity, string url, ...) : Task`
- `GetAsync<T>(string url, ...) : Task<T>`
- `GetAsync<T>(List<Tuple<string,string>> parram, string url, ...) : Task<T>`
- `GetAsync<TRequest,TOutput>(TRequest data, string url, ...) : Task<TOutput>`
- `GetHttpResponseAsync<T>(T data, string url, ...) : Task<HttpResponseMessage>`
- `GetHttpResponseAsync(string url, ...) : Task<HttpResponseMessage>`
- `PostSoapAsync<TRequest,TResponse>(TRequest envelope, string url, Dictionary<string,string> namespaces, ...) : Task<TResponse>`
- `PostSoapAsync(string soap, string url, ...) : Task<string>`
- `PostSoapAsync(XmlDocument doc, string url, string soapAction, ...) : Task<XmlDocument>`
- `PostToSOAAsync<TRequest,TResponse>(TRequest envelope, string url, ... string traceId = "", Dictionary<string,string>? nameSpaces = null, long timeout = 0) : Task<TResponse>`
- `PostDataFormAsync<TRequest,TResponse>(TRequest entity, string url, ... string traceId = "", long timeout = 300) : Task<TResponse>`
- `PostFormAsync<TRequest,TResponse>(TRequest entity, string url, ... string traceId = "", long timeout = 300) : Task<TResponse>`
- `GetUrlFromRequest<T>(T data, string url) : string`
- `ParseObjectToXmlString<T>(T entity, Dictionary<string,string>? namespaces = null) : string`

### 3) Exceptions & ActionResults

- `HttpException : Exception`
  - `StatusCode`
  - `Response`
  - `RequestUrl`
  - `Method`
  - `Content`
  - `IsRetryable`
  - Constructors:
    - `HttpException(string message)`
    - `HttpException(string message, Exception innerException)`
    - `HttpException(string message, HttpResponseMessage httpResponse)`
    - `HttpException(string message, Exception? exception, HttpResponseMessage? httpResponse)`
    - `HttpException(HttpStatusCode statusCode, string message)`
    - `HttpException(HttpStatusCode statusCode, string message, string? content)`

- `HttpException<T> : HttpException`
  - `StatusCode`, `Content` (`T?`)
  - `HttpException(HttpStatusCode statusCode, string message, T? content)`

- `HttpResponseException : ActionResult, IActionResult`
  - Constructors:
    - `HttpResponseException(Exception exception)`
    - `HttpResponseException(HttpStatusCode statusCode, string reason)`
    - `HttpResponseException(HttpStatusCode statusCode, string reason, object value)`
  - Properties: `Value`, `StatusCode`, `Reason`
  - `ExecuteResultAsync(ActionContext context)`

- `StatusCodeObjectResult : ObjectResult`
  - `StatusCodeObjectResult(int httpStatusCode, object? value = null)`
  - `StatusCodeObjectResult(HttpStatusCode httpStatusCode, object? value = null)`

### 4) Models & Collections

- `Endpoints`
  - Properties: `url`, `controller`, `action`, `rules` (`List<string>`)

- `ValidatorModel`
  - `ValidatorModel(List<ValidationResult> validations, int status = 400, string title = "One or more validation errors occurred.")`
  - Properties: `errors` (`JObject`), `type`, `title`, `status`, `traceId`

- `WeakCollection<T> : ICollection<T> where T : class`
  - Lưu item dạng `WeakReference<T>` để không giữ strong reference.
  - Public members:
    - `Add(T item)`
    - `AddRange(List<T> values)`
    - `Clear()`
    - `Count`, `IsReadOnly`
    - `Contains(T item)`
    - `CopyTo(T[] array, int arrayIndex)`
    - `Remove(T item)`
    - `GetEnumerator()`

### 5) Constants

- `MimeTypeNames`
  - Danh sách `public const string` cho các MIME type phổ biến.

- `JwtClaimTypes`
  - Danh sách const cho JWT/OpenID Connect claim types.
  - Nested: `JwtClaimTypes.JwtTypes` chứa các `typ` values chuẩn.

### 6) Claims extensions

Namespace: `NetCore.Utilities.Extensions`

- `ClaimExtensions`
  - `TryGetValue<T>(this IEnumerable<Claim> claims, string type, out T? value, IFormatProvider? provider = null, bool enumIgnoreCase = true) where T : IParsable<T>`
  - `TryGetValue<T>(this ClaimsPrincipal principal, string type, out T? value, IFormatProvider? provider = null, bool enumIgnoreCase = true) where T : IParsable<T>`

- `ClaimsJsonExtensions`
  - `ToClaims(this JArray? array, string defaultTypeForString = ClaimTypes.Role, string defaultIssuer = ClaimsIdentity.DefaultIssuer, string defaultValueType = ClaimValueTypes.String)`
  - `TryToClaims(this JArray? array, out List<Claim> claims, ...)`

---

## Migration note

Các extension gọi HTTP static cũ đã được bỏ khỏi hướng dẫn sử dụng. Code mới phải inject `IDefaultHttpClientService` qua DI.

Thay vì gọi kiểu cũ:

```csharp
// Không sử dụng nữa
// var result = await request.PostAsync<Request, Response>(url, headers, logger, 300, ct);
```

Dùng:

```csharp
var result = await _http.PostAsync<Request, Response>(
    request,
    url,
    headers,
    ct: ct);
```

---

## License

Internal / Enterprise use

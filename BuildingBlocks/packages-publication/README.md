# NetCore Libraries

Bộ thư viện **NetCore** phục vụ các hệ thống nghiệp vụ quy mô lớn (BHXH / DVCLT / e-Government),
tập trung vào **chữ ký số – truy cập CSDL Oracle – tiện ích dùng chung** cho các dự án .NET (Net 6 / 7 / 8).

Repository này hiện cung cấp **3 package chính**, mỗi package có tài liệu riêng chi tiết.

---

## 📦 Danh sách Packages

### 🔐 NetCore.DigitalSignature
**Thư viện kiểm tra chữ ký số và chứng thư số**

Chức năng chính:
- Kiểm tra chữ ký số (XMLDSig / XAdES)
- Kiểm tra trạng thái chứng thư số
  - CRL (Certificate Revocation List)
  - OCSP (Online Certificate Status Protocol)
- Cache thông tin Issuer / CRL
- Phù hợp cho các hệ thống ký số, DVCTT, cổng dịch vụ công

📘 **Tài liệu chi tiết**  
🔗 [`docs/NetCore.DigitalSignature.md`](docs/README.NetCore.DigitalSignature.md)

---

### 🗄️ NetCore.Oracle.DataAccess
**Thư viện truy cập Oracle & chuyển LINQ → Oracle SQL**

Chức năng chính:
- Kết nối Oracle (11g / 12c / 19c)
- Hỗ trợ WorkScope / Unit of Work
- Chuyển biểu thức LINQ thành câu truy vấn Oracle SQL
- Hỗ trợ:
  - Bind variables
  - Array parameters (UDT / TABLE)
  - Hint (INDEX, CARDINALITY…)
- Tối ưu cho hệ thống dữ liệu lớn, bảng partition

📘 **Tài liệu chi tiết**  
🔗 [`docs/NetCore.Oracle.DataAccess.md`](docs/README.NetCore.Oracle.DataAccess.md)

---

### 🧰 NetCore Utilities Suite

Bộ thư viện **NetCore.Utilities** là tập hợp các **utility & infrastructure helpers** dùng chung cho hệ sinh thái .NET / .NET 8, được thiết kế cho:

- Microservice architecture
- Backend API (ASP.NET Core)
- Hệ thống enterprise, nội bộ, yêu cầu chuẩn hóa code

---

#### 📦 Các package trong bộ thư viện

##### ⚜️ NetCore.Utilities (Core)
---
Utilities nền tảng, **không phụ thuộc Web**:
- Extension methods (string, datetime, enum, collection…)
- Result / Guard / Validation helpers
- Reflection & Expression helpers
- JSON & Serialization utilities
- Async / Retry / Diagnostic helpers

📄 Tài liệu chi tiết:  
🔗 [`docs/NetCore.Utilities.md`](docs/README.NetCore.Utilities.md)


##### 📖 Bảng liệt kê Public API (table) cho từng namespace của `NetCore.Utilities`

###### 🔹 Namespace: NetCore.Utilities.Extensions

| API                      | Kiểu      | Mô tả                                            |
| ------------------------ | --------- | ------------------------------------------------ |
| `SafeTrim(this string?)` | Extension | Trim string an toàn, trả `string.Empty` nếu null |
| `IsNullOrEmpty()`        | Extension | Kiểm tra null hoặc rỗng                          |
| `IsNullOrWhiteSpace()`   | Extension | Kiểm tra null hoặc whitespace                    |
| `RemoveAccent()`         | Extension | Bỏ dấu tiếng Việt                                |
| `ToUpperInvariantSafe()` | Extension | UpperCase an toàn                                |
| `ToLowerInvariantSafe()` | Extension | LowerCase an toàn                                |


###### 🔹 Namespace: NetCore.Utilities.Results

| API                      | Kiểu          | Mô tả                        |
| ------------------------ | ------------- | ---------------------------- |
| `Result`                 | Class         | Result pattern không generic |
| `Result<T>`              | Class         | Result pattern generic       |
| `Result.Success()`       | Static method | Tạo result thành công        |
| `Result.Fail(string)`    | Static method | Tạo result lỗi               |
| `Result<T>.Success(T)`   | Static method | Result thành công có data    |
| `Result<T>.Fail(string)` | Static method | Result lỗi có message        |
| `IsSuccess`              | Property      | Trạng thái thành công        |
| `Error`                  | Property      | Thông tin lỗi                |

➡️ Dùng chuẩn hóa luồng xử lý business & API


###### 🔹 Namespace: NetCore.Utilities.Guards

| API                                         | Kiểu          | Mô tả                      |
| ------------------------------------------- | ------------- | -------------------------- |
| `Guard.NotNull(object, string)`             | Static method | Throw nếu null             |
| `Guard.NotNullOrEmpty(string, string)`      | Static method | Throw nếu string rỗng      |
| `Guard.NotNullOrWhiteSpace(string, string)` | Static method | Throw nếu whitespace       |
| `Guard.Against(bool, string)`               | Static method | Throw nếu condition = true |

➡️ Thay thế if + throw rải rác


###### 🔹 Namespace: NetCore.Utilities.Reflection

| API                                         | Kiểu   | Mô tả                      |
| ------------------------------------------- | ------ | -------------------------- |
| `GetPropertyValue(object, string)`          | Method | Lấy value property runtime |
| `SetPropertyValue(object, string, object?)` | Method | Gán value runtime          |
| `HasAttribute<T>()`                         | Method | Kiểm tra attribute         |
| `GetAttribute<T>()`                         | Method | Lấy attribute              |

➡️ Dùng cho dynamic mapping / metadata


###### 🔹 Namespace: NetCore.Utilities.Expressions

| API                           | Kiểu   | Mô tả                        |
| ----------------------------- | ------ | ---------------------------- |
| `ExpressionHelper`            | Class  | Helper xử lý expression tree |
| `GetMemberName(Expression)`   | Method | Lấy tên field/property       |
| `ExtractConstant(Expression)` | Method | Lấy giá trị constant         |
| `IsParameter(Expression)`     | Method | Kiểm tra parameter           |

➡️ Dùng cho LINQ → SQL / Dynamic Query


###### 🔹 Namespace: NetCore.Utilities.Serialization

| API                          | Kiểu   | Mô tả            |
| ---------------------------- | ------ | ---------------- |
| `JsonSerialize(object)`      | Method | Serialize JSON   |
| `JsonDeserialize<T>(string)` | Method | Deserialize JSON |
| `DeepClone<T>(T)`            | Method | Clone object     |
| `SafeConvert<T>(object?)`    | Method | Convert an toàn  |


###### 🔹 Namespace: NetCore.Utilities.Diagnostics

| API                            | Kiểu   | Mô tả                        |
| ------------------------------ | ------ | ---------------------------- |
| `CorrelationIdProvider`        | Class  | Sinh & quản lý CorrelationId |
| `WithCorrelation(string)`      | Method | Gắn correlation vào log      |
| `MeasureExecutionTime(Action)` | Method | Đo thời gian chạy            |

---

##### ⚜️ NetCore.Utilities.Web (ASP.NET Core Extension)
---
Mở rộng cho **ASP.NET Core / Web API**:
- HttpContext & Request helpers
- API Result chuẩn hóa
- Global Exception Middleware
- Logging / Correlation helpers

📄 Tài liệu chi tiết:  
🔗 [`docs/NetCore.Utilities.Web.md`](docs/README.NetCore.Utilities.Web.md)


##### 📖 Bảng liệt kê Public API (table) cho từng namespace của `NetCore.Utilities.Web`

###### 🔹 Namespace: NetCore.Utilities.Web.Http

| API                           | Kiểu      | Mô tả              |
| ----------------------------- | --------- | ------------------ |
| `GetClientIp(HttpContext)`    | Extension | Lấy IP client      |
| `GetUserAgent(HttpContext)`   | Extension | Lấy User-Agent     |
| `GetBearerToken(HttpContext)` | Extension | Lấy JWT token      |
| `GetHeader(string)`           | Extension | Lấy header an toàn |


###### 🔹 Namespace: NetCore.Utilities.Web.ApiResults

| API                      | Kiểu   | Mô tả                  |
| ------------------------ | ------ | ---------------------- |
| `ApiResult`              | Class  | API response chuẩn     |
| `ApiResult<T>`           | Class  | API response generic   |
| `ApiResult.Success()`    | Static | HTTP 200               |
| `ApiResult.Fail(string)` | Static | HTTP lỗi               |
| `FromResult(Result<T>)`  | Static | Mapping từ core Result |

➡️ Chuẩn hóa response toàn hệ thống


###### 🔹 Namespace: NetCore.Utilities.Web.Middleware

| API                           | Kiểu       | Mô tả                     |
| ----------------------------- | ---------- | ------------------------- |
| `GlobalExceptionMiddleware`   | Middleware | Bắt exception toàn cục    |
| `UseGlobalExceptionHandler()` | Extension  | Đăng ký middleware        |
| `ExceptionToStatusCodeMapper` | Class      | Map exception → HTTP code |


###### 🔹 Namespace: NetCore.Utilities.Web.Logging

| API                        | Kiểu       | Mô tả                 |
| -------------------------- | ---------- | --------------------- |
| `RequestLoggingMiddleware` | Middleware | Log request/response  |
| `UseRequestLogging()`      | Extension  | Enable logging        |
| `CorrelationHeader`        | Const      | Header correlation-id |

---

##### ⚜️ NetCore.Utilities.Memcache
---
Thư viện hỗ trợ cache Redis cho .NET theo hướng dùng thực tế trong hệ thống enterprise

📄 Tài liệu chi tiết:  
🔗 [`docs/NetCore.Utilities.Memcache.md`](docs/README.NetCore.Utilities.Memcache.md)

---

## 🎯 Mục tiêu thiết kế

- Nhẹ – dễ đọc – dễ debug
- Không phụ thuộc framework dư thừa
- Dùng tốt cho hệ thống lớn, nhiều service
- Có thể mở rộng thêm CronJob, DataAccess, Messaging…

---

## 📦 Sử dụng NuGet.config để load package nội bộ (Custom NuGet)

Tải các package NetCore được publish từ git về thư mục private NuGet feed (local), cần cấu hình NuGet.config để project có thể restore đúng nguồn.

---
### 🔧 Tạo file `NuGet.config`

Tạo file `NuGet.config` tại root solution:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>

    <!-- Local package feed (đường dẫn tuyệt đối trong container) -->
    <add key="LocalPackages"
         value="./BuildingBlocks/packages-publication" />

    <!-- NuGet chính thức -->
    <add key="nuget.org"
         value="https://api.nuget.org/v3/index.json"
         protocolVersion="3" />
  </packageSources>

  <!-- Ưu tiên feed local -->
  <packageSourceMapping>
    <packageSource key="LocalPackages">
      <package pattern="*" />
    </packageSource>

    <packageSource key="nuget.org">
      <package pattern="*" />
    </packageSource>
  </packageSourceMapping>
</configuration>

```

---

## 📦 Sử dụng công cụ DBO Mapping Generator để tạo class mapping table DB
---
### 📄 Tài liệu chi tiết:  
🔗 [`docs/README_mapping_tool.md`](docs/README_mapping_tool.md)

### 🗄️ Bộ cài đặt

🔗 [`DBOGeneratorInstaller.exe`](DBOGeneratorInstaller.exe)
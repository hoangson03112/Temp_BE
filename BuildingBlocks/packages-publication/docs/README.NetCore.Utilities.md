# NetCore.Utilities

Bộ thư viện **tiện ích dùng chung** cho các dự án .NET (tối ưu cho .NET 8 / microservice). Package tập trung vào các nhóm:

- **Response model** chuẩn hóa để trả về API.
- **Extensions** cho `string`, `collection`, `json`, `xml`, `exception`.
- **Crypto helpers**: AES encrypt/decrypt, hash (SHA256/SHA1), Base64Url, random key.
- **Password utilities**: sinh mật khẩu mạnh, validate theo policy.
- **ASP.NET Core helper**: convert `IFormCollection` → model.

> `NetCore.Utilities.Web` là package mở rộng cùng bộ, bổ sung các helper HTTP/Web.

---

## Cài đặt

```bash
# NuGet
 dotnet add package NetCore.Utilities.Core
```

---
## Quick start

### 1) Response model

```csharp
// Thành công
return new Response(true, "OK");

// Thành công + data
return new Response<MyDto>(true, dto);

// Danh sách + tổng
return new ResponseList<MyDto>(true, "OK", list, total);
```

### 2) JSON helpers

```csharp
var ok = jsonString.IsValidJson();
var base64 = request.ToBase64Json();
var req2 = base64.FromBase64Json<MyRequest>();
```

### 3) Crypto helpers

```csharp
var cipher = "plain".Encrypt();
var plain = cipher.Decrypt();

var id = CryptoRandom.CreateUniqueId(32);
var sha = "abc".SHA256();
```

---

## API Reference (Public)

> Danh sách dưới đây mô tả **toàn bộ public class/method** hiện có trong `NetCore.Utilities`.

### 1) Response models

#### `NetCore.Utilities.Response`
- `Response(bool success, string? type = null)`
  - Tạo response mặc định (status=200, auto `traceId`).
- `Response(bool success, string message, string? type = null)`
  - Tạo response với `Message`.
- `Response(List<ValidationResult> validations, int status = 400, string message = "One or more validation errors occurred.", string? type = null)`
  - Tạo response lỗi validate: build `errors` dạng JSON theo `MemberNames`.
- `Response(Exception exception, int status = 500, string message = "One or more errors occurred.", string traceId = "", string? type = null)`
  - Tạo response lỗi từ exception, gắn `errors["exception"]`.
- `Response(MessageException exception, int status = 500, string message = "One or more errors occurred.", string traceId = "", string? type = null)`
  - Tạo response lỗi từ `MessageException`, gắn `errors["exceptionMessage"]`.

Public properties:
- `bool Success`
- `string Message`
- `JObject errors`
- `int status`
- `string traceId`
- `string type`

#### `NetCore.Utilities.Response<T> where T : class`
- `Response(bool success, T data)`
  - Response thành công với payload `Data`.
- `Response(bool success, string message, T data)`
  - Response với message + `Data`.

Public properties:
- `T Data`

#### `NetCore.Utilities.ResponseList<T>`
- `ResponseList(bool success, string message, List<T> data, long total)`
  - Trả về danh sách `Data` kèm `Total`.

Public properties:
- `List<T> Data`
- `long Total`

---

### 2) Attributes

#### `NetCore.Utilities.CopyAttribute`
- Attribute đánh dấu cho cơ chế copy property.
- Nested attribute: `CopyAttribute.Ignore` (đặt lên property để **bỏ qua** khi `CopyTo`).

#### `NetCore.Utilities.MustBeNullAttribute : ValidationAttribute`
- `override bool IsValid(object value)`
  - Validate giá trị phải null.

---

### 3) Extensions & Helpers

#### `NetCore.Utilities.Base64Url`
- `string Encode(byte[] arg)`
  - Encode Base64 URL-safe (`+`→`-`, `/`→`_`, bỏ `=`).
- `byte[] Decode(string arg)`
  - Decode Base64Url về byte[] (tự pad `=` khi cần).

#### `NetCore.Utilities.BooleanJsonConverter : JsonConverter<bool>`
- `override bool Read(...)`
  - Đọc boolean linh hoạt (hỗ trợ string/number/boolean tuỳ input JSON).
- `override void Write(...)`
  - Ghi boolean ra JSON.

#### `NetCore.Utilities.Extensions.ClaimsJsonExtensions`
- `List<Claim> ToClaims(this JArray? array, string defaultTypeForString = ClaimTypes.Role, string defaultIssuer = ClaimsIdentity.DefaultIssuer, string defaultValueType = ClaimValueTypes.String)`
  - Chuyển `JArray` → `List<Claim>`.
  - Hỗ trợ phần tử primitive (string/int/bool/float) và object (`Type/Value/Issuer/ValueType`).
- `bool TryToClaims(this JArray? array, out List<Claim> claims, ...)`
  - Giống `ToClaims` nhưng **không ném exception**, trả về `false` nếu parse fail.

#### `NetCore.Utilities.CollectionExtension`
- `bool IsNullOrEmpty<T>(this ICollection<T> source)`
  - True nếu null hoặc Count==0.
- `IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> items)`
  - Null-safe: null → `Enumerable.Empty<T>()`.
- `bool IsEmpty<T>(this IEnumerable<T> source)`
  - True nếu không có phần tử.
- `IEnumerable<T> SeparateWith<T>(this IEnumerable<T> items, T separator)`
  - Chèn `separator` vào giữa các phần tử.

#### `NetCore.Utilities.Extensions.ConvertExtend`
- `TConvert CopyTo<TFrom, TConvert>(this TFrom from) where TConvert : new()`
  - Copy property cùng tên (case-insensitive) từ `TFrom` sang `TConvert`.
  - Bỏ qua property có attribute tên `Ignore`.
- `TConvert CopyTo<TConvert>(this object from) where TConvert : new()`
  - Overload nhận object runtime.
- `void CopyStream(this Stream src, Stream dest)`
  - Copy stream theo buffer 1024 bytes.

#### `NetCore.Utilities.CryptoRandom : Random`
- `static byte[] CreateRandomKey(int length)`
  - Tạo key random bằng `RandomNumberGenerator`.
- `static string CreateUniqueId(int length = 32, OutputFormat format = OutputFormat.Base64Url)`
  - Tạo unique id theo format: Base64Url / Base64 / Hex.
- Override từ `Random`:
  - `int Next()` / `int Next(int maxValue)` / `int Next(int minValue, int maxValue)`
  - `double NextDouble()`
  - `void NextBytes(byte[] buffer)`

#### `NetCore.Utilities.EncryptionExtension`
- `string Encrypt(this string clearText, string EncryptionKey = "...", string salt = "...")`
  - AES encrypt (Rfc2898DeriveBytes), output Base64.
- `string Decrypt(this string cipherText, string EncryptionKey = "...", string salt = "...")`
  - AES decrypt.
- `string Base64Encode(this string plainText)` / `string Base64Decode(this string base64EncodedData)`
  - Encode/decode Base64 UTF8.
- `string HashPassword(this string password)`
  - Hash password kiểu PBKDF2 (Rfc2898DeriveBytes) và pack salt+hash ra Base64.
- `string HashPasswordSHA256(this string plainMessage)`
  - SHA256 (Base64 output).
- `string SHA256(this string plainMessage)`
  - SHA256 dạng hex lowercase (không dấu '-').
- `string HashSHA1(this string plainMessage)`
  - SHA1 (dạng string ghép số từng byte).
- `string Hash(this byte[] bytesToHash)`
  - SHA256 cho byte[] và trả về hex.
- `string ToHexString(this IReadOnlyCollection<byte> array)`
  - Chuyển byte[] → hex.
- `byte[] HmacSha256(this byte[] key, string data)`
  - HMAC-SHA256.

#### `NetCore.Utilities.EnvironmentSettings` + `EnvironmentExtensions`
- `EnvironmentSettings.IsDeployment`
  - Cờ môi trường.
- `IServiceCollection AddEnvironment(this IServiceCollection services, bool isDeployment)`
  - Register singleton `EnvironmentSettings` vào DI.

#### `NetCore.Utilities.ExceptionExtend`
- `JObject ToObject(this Exception ex)`
  - Chuyển Exception → JObject (Message/StackTrace/Source/InnerException...).

#### `NetCore.Utilities.FormCollectionExtensions`
- `T AsObject<T>(this IFormCollection pairs, JsonSerializerOptions options) where T : class, new()`
  - Convert form-data thành object T thông qua serialize dictionary → deserialize.

#### `NetCore.Utilities.JsonSeparatorNamingPolicy` / `KebabNamingPolicy`
- `override string ConvertName(string name)`
  - Convert PascalCase/camelCase → kebab-case (hoặc separator policy khác).
- `static JsonNamingPolicy KebabCasing`
  - NamingPolicy dạng kebab-case.

#### `NetCore.Utilities.IReadableStringCollectionExtensions`
- `NameValueCollection AsNameValueCollection(this IEnumerable<KeyValuePair<string, StringValues>> collection)`
- `NameValueCollection AsNameValueCollection(this IDictionary<string, StringValues> collection)`
  - Convert collection headers/query params → `NameValueCollection`.

#### `NetCore.Utilities.JsonExtensions`
- `bool IsValidJson(this string stringValue)`
  - Check string là JSON object/array hợp lệ.
- `IDictionary<string, object> ToDictionary(this JObject @object)`
  - Convert JObject → Dictionary (đệ quy JObject/JArray).
- `object[] ToArray(this JArray array)`
  - Convert JArray → object[] (đệ quy).
- `string ToBase64Json<TRequest>(this TRequest request)`
  - Serialize → JSON → Base64.
- `byte[] ToBytesJson<TRequest>(this TRequest request)`
  - Serialize → JSON → UTF8 bytes.
- `TRequest? FromBase64Json<TRequest>(this string base64)`
  - Base64 → JSON → Deserialize.

#### `NetCore.Utilities.MessageException : Exception`
- `int StatusCode` (field/property public)
- `MessageException(string message)`
- `MessageException(string message, int statusCode)`

#### `NetCore.Utilities.ServiceException : Exception`
- `Exception? Exception { get; set; }`
- `ServiceException(string message)`
- `ServiceException(string message, Exception exception)`

#### `NetCore.Utilities.ServiceException<T> : Exception`
- `Exception? Exception { get; set; }`
- `T Data { get; set; }`
- `ServiceException(string message, T data)`
- `ServiceException(string message, T data, Exception exception)`

#### `NetCore.Utilities.StringExtensions`
- `string ToSpaceSeparatedString(this IEnumerable<string> list)`
  - Ghép danh sách thành chuỗi phân tách bởi space.
- `IEnumerable<string> FromSpaceSeparatedString(this string input)`
  - Parse chuỗi space-separated thành list.
- `List<string>? ParseScopesString(this string scopes)`
  - Parse scopes (space-separated), distinct + sort.
- `bool IsMissing(this string value)` / `bool IsPresent(this string value)`
  - Null/whitespace check.
- `bool IsMissingOrTooLong(this string value, int maxLength)`
  - Check null/empty hoặc vượt max length.
- `string Obfuscate(this string value)`
  - Che chuỗi, chỉ lộ 4 ký tự cuối.
- `string JoinWithAnd(this List<string> list, string separator)`
  - Join list và thêm “and” trước phần tử cuối.
- `string ToUpperFirstLetter(this string str)`
  - Viết hoa chữ cái đầu mỗi từ.
- `string GetSoHienThi(this decimal input)`
  - Format số theo định dạng VN, trim phần thập phân 0.
- `decimal ToDecimal(this string input)`
  - Parse decimal theo culture `en-US`.
- `string GetDiaDiemKy(string tenCoQuan)`
  - Chuẩn hóa địa điểm ký từ tên cơ quan (bỏ prefix, viết hoa chữ đầu).
- `string NumberToCharacterString(double number)`
  - Chuyển số → chữ tiếng Việt (phần nguyên).
- `string ToRoman(this int number)`
  - Chuyển số nguyên → số La Mã.
- `string ObjectToString(object obj)`
  - Serialize object → base64 string (BinaryFormatter).
- `object StringToObject(string base64String)`
  - Deserialize base64 → object (BinaryFormatter).
- `string convertToUnSign(string s)`
  - Bỏ dấu tiếng Việt (unsign).
- `string convertDateString(string date, string format = "dd/MM/yyyy")`
  - Chuẩn hóa chuỗi ngày.

> Lưu ý: `ObjectToString/StringToObject` dùng `BinaryFormatter` (đã bị cảnh báo obsolete trong .NET mới). Nếu dùng trong hệ thống lớn/microservice, nên cân nhắc thay bằng JSON hoặc MessagePack.

#### `NetCore.Utilities.Utf8StringWriter : StringWriter`
- `override Encoding Encoding => Encoding.UTF8`
  - StringWriter UTF8.

#### `NetCore.Utilities.XmlExtensions`
- `T Deserialize<T>(this string toDeserialize)`
  - XML string → object.
- `string Serialize<T>(this T toSerialize)`
  - object → XML string.
- `T ConvertNodeJson<T>(this XmlNode node) where T : class`
  - XmlNode → JSON → object.
- `void ValidateXML(this Stream xmlStream, string xsdPath)`
  - Validate XML theo file XSD.
- `void ValidateXML(this Stream xmlStream, List<byte[]> xsdArray)`
  - Validate XML theo danh sách XSD dạng byte[].

---

### 4) Password

#### `NetCore.Utilities.PasswordUtil`
- `string CreatePasswordInteger(int length)`
  - Sinh chuỗi số ngẫu nhiên (không crypto-safe).
- `string GeneratePassword(int length = 16, bool excludeAmbiguous = true, string? specials = null)`
  - Sinh mật khẩu mạnh (crypto-safe), đảm bảo đủ nhóm: hoa/thường/số/ký tự đặc biệt.
- `string HashRfc2898(this string pwd, string salt)`
  - PBKDF2 (Rfc2898DeriveBytes), output Base64.
- `bool IsValidPassword(this string password, bool requireUpper = true, bool requireLower = true, bool requireDigit = true, bool requireSpecial = true, int minLength = 8)`
  - Validate nhanh theo rule cơ bản.

#### `NetCore.Utilities.Utilities.PasswordPolicy`
- Các cấu hình policy:
  - `PasswordMinLength`, `PasswordMaxLength`
  - `PasswordCharactersUppercaseUsed`, `PasswordCharactersLowercaseUsed`, `PasswordCharactersNumericUsed`, `PasswordCharactersSymbolUsed`
  - `MinDistinctChars`, `MaxRepeatRun`, `MinSequenceLen`, `BannedWords`

#### `NetCore.Utilities.Utilities.PasswordValidator`
- `PasswordValidator(PasswordPolicy policy)`
  - Khởi tạo validator theo policy.
- `ValidationResult? PasswordIsValid(string password, string? username = null, IEnumerable<string>? extraBannedWords = null)`
  - Validate nâng cao:
    - Độ dài + nhóm ký tự
    - Cấm whitespace
    - Chặn lặp ký tự
    - Tối thiểu ký tự khác nhau
    - Chặn sequence (abcd/1234) + đảo ngược
    - Chặn keyboard-walk (qwerty/asdf/zxcv)
    - Chặn mẫu ngày tháng
    - Chặn username / banned words (có normalize leetspeak)

---

## Gợi ý sử dụng trong hệ thống API

- Bạn có thể dùng `Response/Response<T>/ResponseList<T>` làm **contract trả về** thống nhất giữa các microservice.
- Nếu đã có chuẩn RFC7807 (ProblemDetails), bạn có thể map `Response` tương đương hoặc dùng `ValidatorModel` trong package Web.

---

## License
Internal / Enterprise use

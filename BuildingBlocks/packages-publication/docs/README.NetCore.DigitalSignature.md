# NetCore.DigitalSignature.Core

Thư viện kiểm tra **chữ ký số / chứng thư số** dùng trong các hệ thống nghiệp vụ:

- Verify certificate chain (`X509Chain`)
- Check CRL
- Check OCSP (RFC 6960 – BouncyCastle)
- Hỗ trợ **HttpClientFactory + Polly**
- Có thể expose **Prometheus metrics**

---

## Cài đặt

```bash
dotnet add package NetCore.DigitalSignature.Core
```

---

## Cấu hình – Best practice (Cách 1 + Cách 3)

Thư viện áp dụng:

- **Cách 1:** Có cấu hình mặc định trong code; host **override khi cần** qua `appsettings.json`
- **Cách 3:** Package có kèm **file mẫu** `appsettings.DigitalSignature.sample.json` để copy/paste khi cần

> NuGet **không tự tạo file config** trong project consumer để tránh ghi đè cấu hình của ứng dụng.

### Cách khuyến nghị: cấu hình trong `appsettings.json` của host

Thêm section `DigitalSignature`:

```json
{
  "DigitalSignature": {
    "VerifyCertChain": true,
    "CheckOCSP": true,
    "Http": {
      "Crl": {
        "TimeoutSeconds": 10,
        "RetryCount": 2,
        "BaseDelayMs": 200,
        "CircuitBreakFailures": 5,
        "CircuitBreakDurationSeconds": 30
      },
      "Ocsp": {
        "TimeoutSeconds": 8,
        "RetryCount": 1,
        "BaseDelayMs": 150,
        "CircuitBreakFailures": 5,
        "CircuitBreakDurationSeconds": 30
      }
    },
    "IssuerCacheHours": 6
  }
}
```

### File mẫu (đi kèm package)

Trong `.nupkg` có:

```
contentFiles/any/any/appsettings.DigitalSignature.sample.json
```

Bạn có thể copy nội dung file mẫu và dán vào `appsettings.json`.

---

## Đăng ký services

### Mặc định (section `DigitalSignature`)

```csharp
builder.Services.AddDigitalSignature(builder.Configuration);
```

### Đổi section name (nếu cần)

```csharp
builder.Services.AddDigitalSignature(builder.Configuration, sectionName: "MyLib:DigitalSignature");
```

### Override bằng code (không cần appsettings)

```csharp
builder.Services.AddDigitalSignature(builder.Configuration, configure: opt =>
{
    opt.Http.Crl.TimeoutSeconds = 15;
    opt.Http.Ocsp.RetryCount = 0; // tắt retry OCSP
});
```

### Tuỳ chọn: dùng file cấu hình riêng

```csharp
builder.Configuration.AddJsonFile(
    "appsettings.DigitalSignature.json",
    optional: true,
    reloadOnChange: true);
```

---

## Sơ đồ luồng CRL / OCSP

### Luồng CRL (Certificate Revocation List)

```mermaid
flowchart TD
    A[Nhận user certificate] --> B{Kiểm tra thời hạn NotBefore/NotAfter}
    B -->|Hết hạn| X[Return: Expired]
    B -->|Còn hạn| C[Lấy CRL Distribution Points (CDP)]
    C --> D{Có link CDP?}
    D -->|Không| Y[Return: No CDP]
    D -->|Có| E[Chọn URL CDP (thường link đầu)]
    E --> F{CRL cache file đã có?}
    F -->|Có & còn mới| G[Đọc CRL từ file]
    F -->|Không / quá hạn| H[Download CRL (HTTP GET)]
    H --> I{Download OK?}
    I -->|Không| Z[Return: Download failed]
    I -->|OK| G
    G --> J[Parse CRL (BouncyCastle)]
    J --> K{CRL có revoke cert?}
    K -->|Có| R[Return: Revoked]
    K -->|Không| S[Return: Good]
```

**Metrics gợi ý (nếu bật):**
- `ds_crl_download_total{result=success|fail|timeout|error}`
- `ds_crl_download_duration_seconds`

---

### Luồng OCSP (Online Certificate Status Protocol)

```mermaid
flowchart TD
    A[Nhận user certificate] --> B{Có OCSP URL trong AIA?}
    B -->|Không| N[Return: NoOcspUrl]
    B -->|Có| C{Có CA Issuer URL trong AIA?}
    C -->|Không| M[Return: NoIssuerUrl]
    C -->|Có| D[Download/Cache Issuer Certificate]
    D --> E{Issuer load OK?}
    E -->|Không| F[Return: DownloadIssuerFailed]
    E -->|OK| G[Tạo OCSP Request (CertID + Nonce nếu có)]
    G --> H[POST OCSP request]
    H --> I{HTTP/OCSP response OK?}
    I -->|Không| J[Return: ServerError]
    I -->|OK| K[Parse BasicOcspResp]
    K --> L{CertStatus}
    L -->|Good| P[Return: Good]
    L -->|Revoked| Q[Return: Revoked]
    L -->|Unknown| O[Return: Unknown]
```

**Metrics gợi ý (nếu bật):**
- `ds_ocsp_check_total{status=Good|Revoked|Unknown|ServerError|...}`
- `ds_ocsp_check_duration_seconds`
- (nếu có) `ds_ocsp_issuer_download_total`

---

## Sample host app (tham khảo)

Thư mục `sample-host/` trong gói tải về này chứa một Web API minimal để:
- đăng ký `AddDigitalSignature(...)`
- expose `/metrics`
- endpoint test `/ocsp-check` và `/crl-check` (dùng file cert pfx)

Xem hướng dẫn chạy ở `sample-host/README.md`.

📁 Sample host app nằm trong package:
contentFiles/any/any/examples/sample-host
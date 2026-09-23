<div align="center">
<h1 align="center" style="text-align: center;">
  <br>
  <a href="https://git.teca.vn/GDDT-Team/packages.git"><img src="images/Linq.jpg" alt="Linq" width="300" align="center" /></a>
  <br>
  C# Linq to Oracle
  <br>
</h1>

<h4 align="center">Thư viện kết nối database và chuyển đổi từ Linq sang câu query Oracle.</h4>
<h5 align="center"><i>Được phát triển bởi Trần Huy Anh (anhth)</i></h5>
<p align="center">
  <a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0" target="_blank"><img src="https://img.shields.io/badge/.NET-8-%23512BD4?style=flat&labelColor=%23512BD4" alt="NET 8" /></a>
  <a href="#" target="_black"><img src="https://img.shields.io/badge/Linq-C933AA?style=flat&label=%20" alt="Linq" /></a>
  <a href="#" target="_black"><img src="https://img.shields.io/badge/Oracle-F80000?style=flat&logo=oracle&label=%20&labelColor=%23F80000" alt="Oracle" /></a>
  <a href="https://git-scm.com" target="_blank"><img src="https://img.shields.io/badge/git-latest-%23F05032?style=flat&logo=git" alt="Git" /></a>
</p>
</div>

## 📚 Mục lục

- [📝 How To Use](#-how-to-use)
  - [ 1. Khai báo](#1-khai-b%C3%A1o)
  - [ 2. Mapping](#2-mapping)
  - [ 3. Ứng dụng](#3-%E1%BB%A8ng-d%E1%BB%A5ng)
     - [ ‼️ Sử dụng Transaction](#%EF%B8%8F-s%E1%BB%AD-d%E1%BB%A5ng-transaction)
     - [ ‼️ Sử dụng Command](#%EF%B8%8F-s%E1%BB%AD-d%E1%BB%A5ng-command)
- [📖 Documents](#-documents)
- [📌 Các hàm cơ bản](#-các-hàm-cơ-bản)
  - [🔹 ToListAsync](#-tolistasync)
  - [🔹 ToListAsync`<T>`](#-tolistasynct)
  - [🔹 FirstOrDefaultAsync](#-firstordefaultasync)
  - [🔹 FirstOrDefaultAsync`<T>`](#-firstordefaultasynct)
  - [🔹 ToNumberAsync, ToDecimalAsync, ToShortAsync](#-tonumberasync-todecimalasync-toshortasync)
- [📌 Các hàm Execute (SQL/Procedure)](#-các-hàm-execute-sqlprocedure)
  - [🔹 ExecuteNonQueryAsync](#-executenonqueryasync)
  - [🔹 ExecuteProcedureToListAsync`<TOutput>`](#-executeproceduretolistasynctoutput)
  - [🔹 ExecuteProcedureWithOutputsAsync](#-executeprocedurewithoutputsasync)
- [📌 Các hàm DML / Upsert trong Session](#-các-hàm-dml--upsert-trong-session)
  - [🔹 InsertAsync](#-insertasync)
  - [🔹 UpdateAsync](#-updateasync)
  - [🔹 DeleteAsync](#-deleteasync)
  - [🔹 UpdateWithClauseAsync](#-updatewithclauseasync)
  - [🔹 DeleteWithClauseAsync](#-deletewithclauseasync)
  - [🔹 MergeIntoAsync](#-mergeintoasync)
- [📌 Các hàm Oracle](#-các-hàm-oracle)
  - [🔸 Hàm JOIN](#-hàm-join)
  - [🔸 Hàm LEFT JOIN](#-hàm-left-join)
  - [🔸 Hàm IS NULL](#-hàm-is-null)
  - [🔸 Hàm IS NOT NULL](#-hàm-is-not-null)
  - [🔸 Hàm ORDER BY](#-hàm-order-by)
  - [🔸 Hàm EXISTS](#-hàm-exists)
  - [🔸 Hàm IN](#-hàm-in)
  - [🔸 Hàm NVL](#-hàm-nvl)
  - [🔸 Hàm DECODE](#-hàm-decode)
  - [🔸 Hàm SUBSTR](#-hàm-substr)
  - [🔸 Hàm COUNT](#-hàm-count)
  - [🔸 Hàm SUM](#-hàm-sum)
  - [🔸 Hàm DISTINCT](#-hàm-distinct)
  - [🔸 Hàm TRUNC](#-hàm-trunc)
  - [🔸 Hàm ROW_NUMBER](#-hàm-row_number)
  - [🔸 Hàm GROUP BY](#-hàm-group-by)
  - [🔸 Hàm UNION](#-hàm-union)
  - [🔸 Hàm LISTAGG](#-hàm-listagg)
- [📌 Các hàm trong Linq](#-các-hàm-trong-linq)
  - [🔸 Hàm IfGenerateQuery()](#-hàm-ifgeneratequery)
  - [🔸 Hàm IfSelectQuery()](#-hàm-ifselectquery)
  - [🔸 Hàm HaveIfTrue()](#-hàm-haveiftrue)
  - [🔸 Hàm ForUpdateSkipLocked()](#-hàm-forupdateskiplocked)
  - [🔸 Hàm ToDate()](#-hàm-todate)
  - [🔸 Hàm Sequence](#-hàm-sequence)
  - [🔸 Hàm ConnectBy](#-hàm-connectby)
  - [🔸 Hàm ConnectByRoot](#-hàm-connectbyroot)
  - [🔸 Hàm InArray](#-hàm-inarray)
  - [🔸 Hàm XMLTableOfNumber](#-hàm-xmltableofnumber)
  - [🔸 Hàm RegexpReplace](#-hàm-regexpreplace)
  - [🔸 Hàm RegexpLike](#-hàm-regexplike)
  - [🔸 Hàm RegexpInstr](#-hàm-regexpinstr)
  - [🔸 Hàm RegexpSubstr](#-hàm-regexpsubstr)
  - [🔸 Hàm RegexpCount](#-hàm-regexpcount)
  - [🔸 Hàm ReplaceOracle](#-hàm-replaceoracle)
  - [🔸 Hàm Instr](#-hàm-instr)
  - [🔸 Hàm RegexpSubstrToNumber](#-hàm-regexpsubstrtonumber)
  - [🔸 Hàm WithAs và EndWithAsOf](#-hàm-withas-và-endwithasof)
  - [🔸 Hàm HintIndex](#-hàm-hintindex)
- [📌 Các hàm hỗ trợ trong NET](#-các-hàm-hỗ-trợ-trong-net)
  - [🔸 Hàm ConvertToXml](#-hàm-converttoxml)



## 📝 Cài đặt

```bash
dotnet add package NetCore.Oracle.DataAccess
```
Trường hợp muốn monitor bằng metric

```bash
dotnet add package NetCore.Oracle.DataAccess.Core
```

### 1. Khai báo
#### ‼️ Trường hợp đăng ký service trong `Program.cs`
```c#
var builder = WebApplication.CreateBuilder(args);
...
builder.Services.AddDALService(connection_string);
...


#Trường hợp muốn monitor bằng metric
builder.Services.AddDALService(connection_string).AddDbMetrics();
...
var app = builder.Build();
startup.Configure(app, app.Environment);
app.UseHttpMetrics();
app.MapMetrics();
app.Run();
```
#### ‼️ Trường hợp đăng ký service trong `Startup.cs`
```c#
...
services.AddDALService(connection_string);
...
```
##### ‼️ Trường hợp muốn monitor bằng metric

###### 🔹Startup.cs

```c#
services.AddDALService(connection_string).AddDbMetrics();
...
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  ...
  app.UseHttpMetrics();
  app.UseEndpoints(endpoints =>
  {
    ...
  });
}
```

###### 🔹Program.cs
```c#
...
var app = builder.Build();
startup.Configure(app, app.Environment);
app.MapMetrics();
app.Run();
```

#### ‼️ Trường hợp có nhiều database thì phải tạo `class` đại diện cho mỗi database.
```c#
public class DbA { }
public class DbB { }
```
###### 🔹Startup.cs
```c#
services.AddDALService(cfg =>
{
    cfg.Add<DbA>(connection_stringA);
    cfg.Add<DbB>(connection_stringB);
});
...
```
##### ‼️ Trường hợp muốn monitor bằng metric

###### 🔹Startup.cs
```c#
services.AddDALService(cfg =>
{
    cfg.Add<DbA>(connection_stringA);
    cfg.Add<DbB>(connection_stringB);
}).AddDbMetrics();
...
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  ...
  app.UseHttpMetrics();
  app.UseEndpoints(endpoints =>
  {
    ...
  });
}
```

###### 🔹Program.cs
```c#
...
var app = builder.Build();
startup.Configure(app, app.Environment);
app.MapMetrics();
app.Run();
```

###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>database</em></td>
    <td>Bắt buộc. Từ khoá đại diện cho database.</td>
  </tr>
  <tr>
    <td><em>connection_string</em></td>
    <td>Bắt buộc. Chuỗi cấu hình liên kết database.</td>
  </tr>
  </tbody></table>

### 2. Mapping
Sử dụng attribute `MappingDb.TABLE_NAME` của class để cấu hình mapping với tên bảng trong database và `MappingDb.COLUMN_NAME` của từng thuộc tính trong class đó để cấu hình mapping với tên cột trong database.
#### Cú pháp
##### 2.1. Cấu hình TABLE_NAME
```c#
[MappingDb.TABLE_NAME(table_name)]
public class T {
  ...
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên <em>TABLE</em> tương ứng trong database.</td>
  </tr>
  </tbody></table>

##### 2.2. Cấu hình COLUMN_NAME
```c#
[MappingDb.COLUMN_NAME(column_name, [isKey], [dBType], [isVirtual], [sequence])]
public ... column_name { get; set; }
```

###### 📌 Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên <em>COLUMN</em> tương ứng trong database.</td>
  </tr> 
  <tr>
    <td><em>isKey</em></td>
    <td>Không bắt buộc. <code>true</code> nếu là khoá chính của bảng.</td>
  </tr> 
  <tr>
    <td><em>dBType</em></td>
    <td>Không bắt buộc. Kiểu tương ứng theo <code>OracleDbType</code>.<em>(Không có thì bỏ qua)</em></td>
  </tr> 
  <tr>
    <td><em>isVirtual</em></td>
    <td>Không bắt buộc. Xác định xem có phải là cột ảo không <em>(Không có thì bỏ qua)</em><ul><li><code>COLUMN_VIRTUAL.True</code> -> bỏ qua trong các trường hợp Insert, Update, Select từ database.</li><li><code>COLUMN_VIRTUAL.False</code> - Mặc định.</li></ul></td>
  </tr>
  <tr>
    <td><em>sequence</em></td>
    <td>Không bắt buộc. Tên <em>SEQUENCE</em> sẽ gọi để tự sinh khi thực hiện Insert. <em>(Không có thì bỏ qua)</em></td>
  </tr> 
  </tbody></table>

#### Ví dụ
```c#
 [MappingDb.TABLE_NAME("Roles")]
 public class RolesDb
 {
     [MappingDb.COLUMN_NAME("Id", "Seq_Roles")]
     public virtual long Id { get; set; }
     [MappingDb.COLUMN_NAME("Name")]
     public virtual string Name { get; set; }
     [MappingDb.COLUMN_NAME("DisplayName")]
     public virtual string DisplayName { get; set; }
     [MappingDb.COLUMN_NAME("IsActive")]
     public virtual bool IsActive { get; set; }
     [MappingDb.COLUMN_NAME("IsStatic")]
     public virtual bool IsStatic { get; set; }
     [MappingDb.COLUMN_NAME("IsDefault")]
     public virtual bool IsDefault { get; set; }
     [MappingDb.COLUMN_NAME("Description")]
     public virtual string Description { get; set; }
     [MappingDb.COLUMN_NAME("ConcurrencyStamp")]
     public virtual string ConcurrencyStamp { get; set; }
     [MappingDb.COLUMN_NAME("CreationTime")]
     public virtual DateTime CreationTime { get; set; }
     [MappingDb.COLUMN_NAME("CreatorUserId")]
     public virtual long? CreatorUserId { get; set; }
     [MappingDb.COLUMN_NAME("LastModificationTime")]
     public virtual DateTime? LastModificationTime { get; set; }
     [MappingDb.COLUMN_NAME("LastModifierUserId")]
     public virtual long? LastModifierUserId { get; set; }
     [MappingDb.COLUMN_NAME("IsDeleted")]
     public virtual bool IsDeleted { get; set; }
     [MappingDb.COLUMN_NAME("DeletionTime")]
     public virtual DateTime? DeletionTime { get; set; }
     [MappingDb.COLUMN_NAME("DeleterUserId")]
     public virtual long? DeleterUserId { get; set; }
     [MappingDb.COLUMN_NAME("OrganizationId")]
     public virtual int OrganizationId { get; set; }
     [MappingDb.COLUMN_NAME("ClientStoreId")]
     public virtual long ClientStoreId { get; set; }
 }
```

### 3. Ứng dụng
Trong ứng dụng mẫu, service `IDbSession` được yêu cầu và sử dụng để gọi các phương thức `ToListAsync()`,`GetAll()`,`Insert`,`Update`,...
```c#
public class Index2Model : PageModel
{
    private readonly IDbSession _db;

    public Index2Model(IDbSession db)
    {
        _db = db;            
    }

    public void OnGet()
    {
      var result = await _db.ToListAsync(...);
    }
}
```
Để select được từ 1 `TABLE` ta phải sử dụng `GetAll`:
```c#
from t in _db.GetAll<table_name>() 
where condition
select column_name
```
##### Ví dụ:
```c#
public class ValueController : ControllerBase
{
    private readonly IDbSession _db;

    public ValueController(IDbSession db)
    {
        _db = db;            
    }
    [HttpGet]
    public  async Task<IActionResult> Get(long userId)
    {
      var result = await _db.FirstOrDefaultAsync(from u in _db.GetAll<UsersDb>()
                                                  where u.Id == userId
                                                  select u);
      return Ok(result);
    }
}
```
#### ‼️ Sử dụng Transaction

```c#
await using var scope = await _db.BeginScopeAsync();
var transaction = scope.Transaction;

\\Commit
await scope.CommitAsync();

\\Rollback
await scope.RollbackAsync();

```
#### ‼️ Sử dụng Command

```c#
await using var cmd = scope.CreateCommand();
...
```

## 📖 Documents
## 📌 Các hàm cơ bản
### 🔹 ToListAsync
----------------------------
#### Định nghĩa và cách sử dụng
Lấy ra một danh sách từ database
#### Cú pháp
```c#
IDbSession.ToListAsync([SqlCommand], [SqlTransaction], query, comment, isMapping, orderBy);
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>SqlCommand</em></td>
    <td>Không bắt buộc. <code>Command</code> nếu được khởi tạo sẵn từ ngoài.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>SqlTransaction</em></td>
    <td>Không bắt buộc. <code>Transaction</code> nếu được khởi tạo chung từ ngoài.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>query</em></td>
    <td>Bắt buộc. <code>IQueryable</code> của 1 đối tượng (class) hoặc 1 đối tượng dạng <em>Anonymos</em>.</td>
  </tr>
  <tr>
    <td><em>comment</em></td>
    <td>Không bắt buộc. Comment vào phần <em>SELECT</em> khi query SQL được tạo ra nếu có (ví dụ như Hint Index <code>IX_DKCN_PATCH_SOHOSO</code>:  <code>SELECT /*+ INDEX(D IX_DKCN_PATCH_SOHOSO) */</code> sẽ truyền <code>comment: "INDEX(D IX_DKCN_PATCH_SOHOSO)"</code>).<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>isMapping</em></td>
    <td>Không bắt buộc.<ul><li><code>true</code> nếu đầu ra là 1 đối tượng đã cấu hình <code>MappingDb.COLUMN_NAME</code>.</li><li><code>false</code> nếu đầu ra là 1 đối tượng dạng <em>Anonymos</em> (<code>new { property1 = ..., property2 = ..., ...}</code>).</li></ul><br /><em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>orderBy</em></td>
    <td>Không bắt buộc. Tên thuộc tính dùng để sắp xếp theo thứ tự tăng dần.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  </tbody></table>

#### Ví dụ
##### Trường hợp đầu vào là `IQueryable` của 1 class
```c#
var userDb = await _db.ToListAsync(from u in _db.GetAll<UsersDb>()
                                    where u.Id == userId
                                    select u);
```
##### Trường hợp đầu vào là `IQueryable` của 1 đối tượng dạng Anonymos
```c#
var userDb = await _db.ToListAsync(from u in _db.GetAll<UsersDb>()
                                    where u.Id == userId
                                    select new
                                    {
                                        u.Email,
                                        u.Address,
                                        u.Birthday,
                                        u.Gender,
                                        u.PhoneNumber,
                                        u.UserName,
                                        u.Department,
                                        u.Position,
                                        u.Picture,
                                        u.NormalizedUserName
                                    }, isMapping: false);
```

### 🔹 ToListAsync`<T>`
-----------------------------------
#### Định nghĩa và cách sử dụng
Tương tự như `ToListAsync` nhưng `IQueryable` là của 1 đối tượng dạng Anonymos và danh sách sẽ tự chuyển đổi về danh sách của `T`
#### Cú pháp
```c#
IDbSession.ToListAsync<T>([SqlCommand], [SqlTransaction], query, comment, isMapping: false, orderBy);
```
#### Ví dụ
```c#
var userDb = await _db.ToListAsync<UsersDto>(from u in _db.GetAll<UsersDb>()
                                              where u.Id == userId
                                              select new
                                              {
                                                  u.Email,
                                                  u.Address,
                                                  u.Birthday,
                                                  u.Gender,
                                                  u.PhoneNumber,
                                                  u.UserName,
                                                  u.Department,
                                                  u.Position,
                                                  u.Picture,
                                                  u.NormalizedUserName
                                              }, isMapping: false);
```

### 🔹 FirstOrDefaultAsync
----------------------------
#### Định nghĩa và cách sử dụng
Lấy ra một dòng dữ liệu từ database
#### Cú pháp
```c#
IDbSession.FirstOrDefaultAsync([SqlCommand], [SqlTransaction], query, comment, isMapping, orderBy);
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>SqlCommand</em></td>
    <td>Không bắt buộc. <code>Command</code> nếu được khởi tạo sẵn từ ngoài.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>SqlTransaction</em></td>
    <td>Không bắt buộc. <code>Transaction</code> nếu được khởi tạo chung từ ngoài.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>query</em></td>
    <td>Bắt buộc. <code>IQueryable</code> của 1 đối tượng (class) hoặc 1 đối tượng dạng <em>Anonymos</em>.</td>
  </tr>
  <tr>
    <td><em>comment</em></td>
    <td>Không bắt buộc. Comment vào phần <em>SELECT</em> khi query SQL được tạo ra nếu có (ví dụ như Hint Index <code>IX_DKCN_PATCH_SOHOSO</code>:  <code>SELECT /*+ INDEX(D IX_DKCN_PATCH_SOHOSO) */</code> sẽ truyền <code>comment: "INDEX(D IX_DKCN_PATCH_SOHOSO)"</code>).<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>isMapping</em></td>
    <td>Không bắt buộc.<ul><li><code>true</code> nếu đầu ra là 1 đối tượng đã cấu hình <code>MappingDb.COLUMN_NAME</code>.</li><li><code>false</code> nếu đầu ra là 1 đối tượng dạng <em>Anonymos</em> (<code>new { property1 = ..., property2 = ..., ...}</code>).</li></ul><br /><em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>orderBy</em></td>
    <td>Không bắt buộc. Tên thuộc tính dùng để sắp xếp theo thứ tự tăng dần.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  </tbody></table>

#### Ví dụ
##### Trường hợp đầu vào là `IQueryable` của 1 class
```c#
var userDb = await _db.FirstOrDefaultAsync(from u in _db.GetAll<UsersDb>()
                                            where u.Id == userId
                                            select u);
```
##### Trường hợp đầu vào là `IQueryable` của 1 đối tượng dạng Anonymos
```c#
var userDb = await _db.FirstOrDefaultAsync(from u in _db.GetAll<UsersDb>()
                                            where u.Id == userId
                                            select new
                                            {
                                                u.Email,
                                                u.Address,
                                                u.Birthday,
                                                u.Gender,
                                                u.PhoneNumber,
                                                u.UserName,
                                                u.Department,
                                                u.Position,
                                                u.Picture,
                                                u.NormalizedUserName
                                            }, isMapping: false);
```

### 🔹 FirstOrDefaultAsync`<T>`
---------------------------------------
#### Định nghĩa và cách sử dụng
Tương tự như `FirstOrDefaultAsync` nhưng `IQueryable` là của 1 đối tượng dạng Anonymos và danh sách sẽ tự chuyển đổi về danh sách của `T`
#### Cú pháp
```c#
IDbSession.FirstOrDefaultAsync<T>([SqlCommand], [SqlTransaction], query, comment, isMapping: false, orderBy);
```
#### Ví dụ
```c#
var userDb = await _db.FirstOrDefaultAsync<UsersDto>(from u in _db.GetAll<UsersDb>()
                                                      where u.Id == userId
                                                      select new
                                                      {
                                                          u.Email,
                                                          u.Address,
                                                          u.Birthday,
                                                          u.Gender,
                                                          u.PhoneNumber,
                                                          u.UserName,
                                                          u.Department,
                                                          u.Position,
                                                          u.Picture,
                                                          u.NormalizedUserName
                                                      }, isMapping: false);
```

### 🔹 ToNumberAsync, ToDecimalAsync, ToShortAsync
----------------------------
#### Định nghĩa và cách sử dụng
Lấy ra một giá trị kiểu số từ database. Thường được dùng để tính `COUNT` hoặc `SUM` hoặc lấy `SEQUENCE`
#### Cú pháp
```c#
IDbSession.ToNumberAsync<TKey>([SqlCommand], [SqlTransaction], query, comment, isMapping);
IDbSession.ToDecimalAsync([SqlCommand], [SqlTransaction], query, comment, isMapping);
IDbSession.ToShortAsync([SqlCommand], [SqlTransaction], query, comment, isMapping);
```
##### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>SqlCommand</em></td>
    <td>Không bắt buộc. <code>Command</code> nếu được khởi tạo sẵn từ ngoài.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>SqlTransaction</em></td>
    <td>Không bắt buộc. <code>Transaction</code> nếu được khởi tạo chung từ ngoài.<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>query</em></td>
    <td>Bắt buộc. <code>IQueryable</code> của thủ tục lấy ra 1 giá trị kiểu số.<br />eg: <code>... select 1.Count()</code></td>
  </tr>
  <tr>
    <td><em>comment</em></td>
    <td>Không bắt buộc. Comment vào phần <em>SELECT</em> khi query SQL được tạo ra nếu có (ví dụ như Hint Index <code>IX_DKCN_PATCH_SOHOSO</code>:  <code>SELECT /*+ INDEX(D IX_DKCN_PATCH_SOHOSO) */</code> sẽ truyền <code>comment: "INDEX(D IX_DKCN_PATCH_SOHOSO)"</code>).<em>(Không có thì bỏ qua)</em></td>
  </tr>
  <tr>
    <td><em>isMapping</em></td>
    <td>Bắt buộc. Giá trị cố định: <code>true</code></td>
  </tr>
  <tr>
    <td><em>TKey</em></td>
    <td>Kiểu giá trị trả về</td>
  </tr>
  </tbody></table>

#### Ví dụ
```c#
var userDb = await _db.ToNumberAsync<long>(from u in _db.GetAll<UsersDb>()
                                            where u.Id == userId
                                            select 1.Count());
```

---
## 📌 Các hàm Execute (SQL/Procedure)

### 🔹 ExecuteNonQueryAsync
----------------------------
#### Định nghĩa và cách sử dụng
Thực thi một câu lệnh SQL dạng **DML/DDL** (INSERT/UPDATE/DELETE, CREATE/ALTER, …) và trả về **số dòng bị ảnh hưởng**.

#### Cú pháp
```c#
IDbSession.ExecuteNonQueryAsync(sql, ct);
```

###### Parameter Values
| Parameter | Description |
|----------|-------------|
| `sql` | Bắt buộc. Câu lệnh SQL cần thực thi. |
| `ct` | Không bắt buộc. `CancellationToken` để huỷ thao tác. |

#### Ví dụ
```c#
var affected = await _db.ExecuteNonQueryAsync(
    "UPDATE USERS SET IS_ACTIVE = 0 WHERE LAST_LOGIN < ADD_MONTHS(SYSDATE, -6)"
);
```

---

### 🔹 ExecuteProcedureToListAsync`<TOutput>`
-----------------------------------
#### Định nghĩa và cách sử dụng
Gọi **Stored Procedure** và map kết quả trả về thành danh sách `List<TOutput>` (thường dùng với `REF CURSOR`).

#### Ví dụ
```c#
var rs = await _db.ExecuteProcedureToListAsync<UserDto>(
    "PKG_USER.PR_GET_USERS",
    isMapping: true,
    parameters: new OracleParameter[]
    {
        new("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
    }
);
```

---

### 🔹 ExecuteProcedureWithOutputsAsync
-----------------------------------
#### Định nghĩa và cách sử dụng
Gọi **Stored Procedure** và nhận lại các tham số **OUT/INOUT** dưới dạng `Dictionary<string, object>`.

#### Ví dụ
```c#
var outputs = await _db.ExecuteProcedureWithOutputsAsync(
    "PKG_USER.PR_CREATE_USER",
    new Dictionary<string, (object?, OracleDbType, ParameterDirection)>
    {
        ["p_user_id"] = (null, OracleDbType.Int64, ParameterDirection.Output)
    }
);
```

---


## 📌 Các hàm DML / Upsert trong Session

### 🔹 InsertAsync
----------------------------
#### Định nghĩa và cách sử dụng
Thêm mới dữ liệu vào bảng theo mapping `TABLE_NAME` / `COLUMN_NAME` của entity. Thư viện hỗ trợ chèn **1 bản ghi** hoặc **danh sách bản ghi**, đồng thời có nhiều overload để chạy trực tiếp, chạy trong `Transaction`, hoặc tái sử dụng `OracleCommand`.

#### Trường hợp nên dùng
- Insert entity đã map trực tiếp với bảng Oracle
- Insert hàng loạt nhiều bản ghi cùng kiểu
- Cần dùng chung transaction với nhiều thao tác khác

#### Các dạng overload thường dùng
```csharp
await _db.InsertAsync(entity, ct);
await _db.InsertAsync(listEntity, ct);
await _db.InsertAsync(transaction, entity, ct: ct);
await _db.InsertAsync(command, transaction, entity, ct: ct);
```

#### Ghi chú
- Các cột có `sequence` trong `MappingDb.COLUMN_NAME(...)` sẽ được tự sinh khi insert.
- Các cột đánh dấu virtual sẽ bị bỏ qua khi sinh câu lệnh insert.
- `isMapping = true` dùng khi entity là class đã map cột; thường để mặc định.

#### Ví dụ
```csharp
var entity = new UsersDb
{
    Name = "Nguyen Van A",
    Email = "a@example.com",
    CreationTime = DateTime.Now
};

await _db.InsertAsync(entity, ct);
```

```csharp
await using var scope = await _db.BeginScopeAsync();
var tran = scope.Transaction;

await _db.InsertAsync(tran, entity, ct: ct);
await scope.CommitAsync(ct);
```

### 🔹 UpdateAsync
----------------------------
#### Định nghĩa và cách sử dụng
Cập nhật dữ liệu của entity theo mapping khóa/cột của đối tượng. Hỗ trợ cập nhật **1 bản ghi** hoặc **danh sách bản ghi**. Có thể truyền `columnClause` để chỉ rõ các cột được phép update.

#### Trường hợp nên dùng
- Update toàn bộ entity đã đọc từ DB và chỉnh sửa lại
- Batch update nhiều entity cùng kiểu
- Chỉ muốn update một số cột xác định bằng `columnClause`

#### Các dạng overload thường dùng
```csharp
await _db.UpdateAsync(entity, ct: ct);
await _db.UpdateAsync(listEntity, ct: ct);
await _db.UpdateAsync(transaction, entity, columnClause: "NAME,EMAIL", ct: ct);
await _db.UpdateAsync(command, transaction, entity, columnClause: "NAME,EMAIL", ct: ct);
```

#### Ghi chú
- `columnClause` là danh sách cột muốn update, dùng khi không muốn sinh update cho toàn bộ cột map được.
- Điều kiện `WHERE` thường dựa trên các cột khóa đã cấu hình trong entity.
- Phù hợp khi bạn đã có entity đầy đủ; nếu muốn update theo biểu thức LINQ thì dùng [`UpdateWithClauseAsync`](#-updatewithclauseasync).

#### Ví dụ
```csharp
user.Email = "newmail@example.com";
user.LastModificationTime = DateTime.Now;

await _db.UpdateAsync(user, columnClause: "EMAIL,LASTMODIFICATIONTIME", ct: ct);
```

### 🔹 DeleteAsync
----------------------------
#### Định nghĩa và cách sử dụng
Xóa dữ liệu dựa trên entity đã map. Hỗ trợ xóa **1 bản ghi** hoặc **danh sách bản ghi**, và có thể chạy trong `Transaction`/`Command` có sẵn.

#### Trường hợp nên dùng
- Xóa theo entity hoặc theo khóa đã có sẵn trong object
- Xóa hàng loạt một tập entity đã truy ra trước đó

#### Các dạng overload thường dùng
```csharp
await _db.DeleteAsync(entity, ct: ct);
await _db.DeleteAsync(listEntity, ct: ct);
await _db.DeleteAsync(command, transaction, entity, ct: ct);
```

#### Ghi chú
- `DeleteAsync` phù hợp khi điều kiện xóa dựa trên khóa của entity.
- Nếu muốn xóa theo biểu thức LINQ như `where x.Status == 0`, dùng [`DeleteWithClauseAsync`](#-deletewithclauseasync).

#### Ví dụ
```csharp
await _db.DeleteAsync(user, ct: ct);
```

### 🔹 UpdateWithClauseAsync
----------------------------
#### Định nghĩa và cách sử dụng
Sinh câu lệnh `UPDATE ... SET ... WHERE ...` trực tiếp từ `Expression Tree`. Đây là cách phù hợp khi bạn muốn mô tả câu update bằng LINQ thay vì phải tạo entity hoàn chỉnh.

#### Trường hợp nên dùng
- Update theo điều kiện hàng loạt
- Update một số cột theo biểu thức
- Muốn tránh đọc dữ liệu lên rồi mới update lại

#### Cú pháp
```csharp
int affectedRows = await _db.UpdateWithClauseAsync<TSource>(
    update: x => new TSource { ... },
    where: x => ...,
    ct: ct);
```

`affectedRows` là số bản ghi được Oracle cập nhật, tương ứng với giá trị trả về từ `ExecuteNonQueryAsync`.

#### Các overload thường dùng
```csharp
int affectedRows = await _db.UpdateWithClauseAsync<UsersDb>(
    x => new UsersDb { IsActive = false },
    x => x.LastLogin < fromDate,
    ct);

affectedRows = await _db.UpdateWithClauseAsync<UsersDb>(
    transaction,
    x => new UsersDb { IsActive = false },
    x => x.LastLogin < fromDate,
    ct);

affectedRows = await _db.UpdateWithClauseAsync<UsersDb>(
    command, transaction,
    x => new UsersDb { IsActive = false },
    x => x.LastLogin < fromDate,
    ct);
```

#### Ghi chú
- `update` là biểu thức mô tả các cột cần `SET`.
- `where` là biểu thức điều kiện lọc bản ghi cần update.
- Giá trị trả về là số bản ghi được Oracle cập nhật; bằng `0` khi không có bản ghi nào thỏa điều kiện `where`.
- Có overload `tableName` để ép ghi vào tên bảng cụ thể nếu cần override mapping mặc định.

#### Ví dụ
```csharp
var affectedRows = await _db.UpdateWithClauseAsync<HosoChangeLogDb>(
    x => new HosoChangeLogDb
    {
        Processed = 1
    },
    x => x.Id <= lastId && x.Processed == 0,
    ct);

if (affectedRows == 0)
{
    // Không có bản ghi nào thỏa điều kiện cập nhật.
}
```

### 🔹 DeleteWithClauseAsync
----------------------------
#### Định nghĩa và cách sử dụng
Sinh câu lệnh `DELETE FROM ... WHERE ...` trực tiếp từ `Expression Tree`. Phù hợp khi cần xóa theo điều kiện mà không phải dựng entity trước.

#### Trường hợp nên dùng
- Dọn dữ liệu lịch sử / dữ liệu tạm
- Xóa theo điều kiện nghiệp vụ động
- Kết hợp với transaction xử lý batch

#### Cú pháp
```csharp
await _db.DeleteWithClauseAsync<TSource>(
    where: x => ...,
    ct: ct);
```

#### Các overload thường dùng
```csharp
await _db.DeleteWithClauseAsync<LogDb>(
    x => x.CreatedAt < keepFromDate,
    ct);

await _db.DeleteWithClauseAsync<LogDb>(
    transaction,
    x => x.CreatedAt < keepFromDate,
    ct);

await _db.DeleteWithClauseAsync<LogDb>(
    command, transaction,
    x => x.CreatedAt < keepFromDate,
    ct);
```

#### Ví dụ
```csharp
await _db.DeleteWithClauseAsync<HosoParticipationRmDb>(
    x => x.HosoId == hosoId,
    ct);
```

### 🔹 MergeIntoAsync
----------------------------
#### Định nghĩa và cách sử dụng
Sinh và thực thi câu lệnh Oracle `MERGE INTO` từ `Expression Tree`. Hàm này phù hợp cho bài toán **upsert**: nếu bản ghi đã tồn tại thì `UPDATE`, nếu chưa tồn tại thì `INSERT`.

#### Trường hợp nên dùng
- Đồng bộ read model / summary table
- Upsert dữ liệu từ một `source IQueryable`
- Thay thế pattern “kiểm tra tồn tại rồi update/insert” để tránh nhiều round-trip

#### Cú pháp
```csharp
await _db.MergeIntoAsync<TTarget, TSource>(
    source,
    on: (t, s) => ...,
    whenMatchedUpdate: (t, s) => new TTarget { ... },
    whenNotMatchedInsert: s => new TTarget { ... },
    ct: ct);
```

#### Các overload thường dùng
```csharp
await _db.MergeIntoAsync<HosoReadModelDb, HosoSnapshotDto>(
    source,
    (t, s) => t.HosoId == s.HosoId,
    (t, s) => new HosoReadModelDb
    {
        Ten = s.Ten,
        Sohoso = s.SoHoSo,
        RmUpdatedAt = DateTime.Now
    },
    s => new HosoReadModelDb
    {
        HosoId = s.HosoId,
        Ten = s.Ten,
        Sohoso = s.SoHoSo,
        RmCreatedAt = DateTime.Now,
        RmUpdatedAt = DateTime.Now
    },
    ct);
```

```csharp
await _db.MergeIntoAsync<HosoReadModelDb, HosoSnapshotDto>(
    transaction,
    "GDDT_STATIC.HOSO_READMODEL",
    source,
    (t, s) => t.HosoId == s.HosoId,
    (t, s) => new HosoReadModelDb
    {
        Ten = s.Ten,
        Sohoso = s.SoHoSo,
        RmUpdatedAt = DateTime.Now
    },
    s => new HosoReadModelDb
    {
        HosoId = s.HosoId,
        Ten = s.Ten,
        Sohoso = s.SoHoSo,
        RmCreatedAt = DateTime.Now,
        RmUpdatedAt = DateTime.Now
    },
    ct);
```

#### Ghi chú
- `source` là truy vấn LINQ dùng làm nguồn cho mệnh đề `USING (...)`.
- `on` mô tả điều kiện match giữa bảng đích và nguồn.
- `whenMatchedUpdate` mô tả phần `WHEN MATCHED THEN UPDATE`.
- `whenNotMatchedInsert` mô tả phần `WHEN NOT MATCHED THEN INSERT`.
- Có overload `tableName` để chỉ rõ bảng đích, hữu ích khi muốn ghi vào schema/tên bảng cụ thể.

## 📌 Các hàm Oracle
### 🔸 Hàm JOIN
---------------

<p>Ví dụ:</p>
```c#
from r in _ws.GetAll<RolesDb>()
join ur in _ws.GetAll<UserRolesDb>() on r.Id equals ur.RoleId
...
```
<p>Trường hợp join với nhiều điều kiện </p>

```c#
from u in _db.GetAll<UsersDb>()
join uc in _db.GetAll<UserClientDb>() on new { a = u.Id, b = true } equals new { a = uc.UserId, b = uc.IsActive }
...
```

### 🔸 Hàm LEFT JOIN
---------------
`IsLeftJoin()`
<br />
Dùng để left join 2 Table với nhau, tương tự như với join nhưng thêm hàm `.IsLeftJoin()` ở cuối.
<p>Ví dụ:</p>
```c#
from r in _ws.GetAll<RolesDb>()
join ur in _ws.GetAll<UserRolesDb>().IsLeftJoin() on r.Id equals ur.RoleId
...
```
Tương đương với câu lệnh trong Oracle
```sql
...
FROM Roles r LEFT JOIN UserRoles ur ON r.Id = ur.RoleId
...
```
Trường hợp left join với nhiều điều kiện 

```c#
from u in _db.GetAll<UsersDb>()
join uc in _db.GetAll<UserClientDb>().IsLeftJoin() on new { a = u.Id, b = true } equals new { a = uc.UserId, b = uc.IsActive }
...
```

### 🔸 Hàm IS NULL
---------------
Có thể sử dụng với các câu lệnh như `string.IsNullOrEmpty()`, `string.IsNullOrWhiteSpace()` hoặc `.IsNull()`
<p>Ví dụ:</p>
```c#
// string.IsNullOrEmpty()
from t in _db.GetAll<TestDb>()
where string.IsNullOrEmpty(clientName)

// string.IsNullOrWhiteSpace()
from t in _db.GetAll<TestDb>()
where string.IsNullOrEmpty(clientName)

// .IsNull()
from t in _db.GetAll<TestDb>()
where clientName.IsNull()
```

### 🔸 Hàm IS NOT NULL
---------------
Sử dụng tương tự như đối với `string.IsNullOrEmpty()` `string.IsNullOrWhiteSpace()` `.IsNull()` nhưng thêm `!` đằng trước.
<p>Ví dụ:</p>
```c#
// string.IsNullOrEmpty()
from t in _db.GetAll<TestDb>()
where !string.IsNullOrEmpty(clientName)

// string.IsNullOrWhiteSpace()
from t in _db.GetAll<TestDb>()
where !string.IsNullOrEmpty(clientName)

// .IsNull()
from t in _db.GetAll<TestDb>()
where !clientName.IsNull()
```

### 🔸 Hàm ORDER BY
---------------
#### `orderby`
Lưu ý: Không áp dụng với cách viết Linq Lambda
<br />
Để Order by `DESC` thì sử dụng `descending`
<p>Ví dụ:</p>
```c#
public async Task<object> Test(string clientName)
{
    var result = await _db.ToListAsync((from t in _db.GetAll<TestDb>()
                                       where string.IsNullOrWhiteSpace(clientName)
                                       orderby t.DateNumber descending, t.Id 
                                       select new
                                       {
                                           Date = t.DateString.ToDate("yyyyMMdd"),
                                           Date2 = t.DateNumber.ToDate("yyyyMM")
                                       }), isMapping: false);
    return result;
}
```

### 🔸 Hàm EXISTS
----------------------
<p>Ví dụ:</p>
```c#
var a = await _db.ToListAsync(from p in _db.GetAll<PermissionsDb>()
                              where (from g in _db.GetAll<GrantPermissionsDb>() where g.PermissionsId == p.Id select 1).Exists()
                              select p, isMapping: false);
```

### 🔸 Hàm IN
------------------------
Cấu trúc dạng ... WHERE A `IN` (SELECT ... FROM ...)
<p>Ví dụ:</p>
```c#
var a = await _db.ToListAsync(from p in _db.GetAll<PermissionsDb>()
                              where (from g in _db.GetAll<GrantPermissionsDb>() where g.IsGranted == true && g.Type == GrantType.IsUser select g.PermissionsId).Any(x => x == p.Id)
                              select p, isMapping: false);
```
Tương đương với câu lệnh trong Oracle
```sql
...
FROM Permissions p 
WHERE p.Id IN ( SELECT g.PermissionsId AS PermissionsId FROM GrantPermissions g WHERE ((g.IsGranted = @p1) AND (g.Type = @p2)))
```

### 🔸 Hàm NVL
------------------------------------
##### Định nghĩa và cách sử dụng
Cấu trúc trong `Linq` sẽ là:
<br />
`T.<property>.NVL(<giá trị thay thế khi NULL>)`
<p>Ví dụ:</p>
```c#
...
where g.Loaigiaodich.NVL(0) == 1
...
```
Tức là nếu gặp giá trị `NULL` của cột `Loaigiaodich` thì sẽ được thay thế bẳng giá trị 0

### 🔸 Hàm DECODE
--------------------------------------
Hàm `DECODE()` trả về một giá trị nếu điều kiện là `TRUE` hoặc trả về một giá trị khác nếu điều kiện là `FALSE`.
<br />
Cấu trúc trong `Linq` sẽ là:
<br />
`T.<property>.Decode(new DecodeClause<<Kiểu của giá trị so sánh>, <kiểu của kết quả>>[] {new (<Giá trị so sánh 1>, <Kết quả 1>), new (<Giá trị so sánh 2>, <Kết quả 2>, ..., new (<Giá trị so sánh n>, <Kết quả n>)}, <Giá trị kết quả mặc định>)`
<p>Ví dụ:</p>
```c#
...
where p.Type.Decode(new DecodeClause<string, int>[] {new ("MENU", 1), new ("FUNC", 2) }, 3) == 1
...
```

### 🔸 Hàm SUBSTR
---------------------------------------
##### Định nghĩa và cách sử dụng
Hàm `SUBSTR()` trích xuất một số ký tự từ một chuỗi.
<br />
Ví dụ: Trích xuất 3 ký tự từ một chuỗi, bắt đầu ở vị trí 1:
```sql
SELECT SUBSTR('SQL Tutorial', 1, 3) AS ExtractString;
```
###### Cú pháp
Cấu trúc trong `Linq` sẽ là:
<br />
`T.<property>.Substr(<start>, <length>)`
##### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>property</em></td>
    <td>Bắt buộc. Thuộc tính đại diện chuỗi COLUMN trong DB sẽ trích xuất.</td>
  </tr>
  <tr>
    <td><em>start</em></td>
    <td>Bắt buộc. Vị trí bắt đầu. Vị trí đầu tiên trong <em>chuỗi</em> là 1</td>
  </tr>
  <tr>
    <td><em>length</em></td>
    <td>Bắt buộc. Số lượng ký tự cần trích xuất. Phải là một số dương</td>
  </tr>
  </tbody></table>
<br />
<p>Ví dụ:</p>
```c#
...
p.Hoten.Substr(1, 3)
...
```

### 🔸 Hàm COUNT
-------------------------------------
#### ➥ COUNT()
----------------------------------
##### Định nghĩa và cách sử dụng
Hàm `COUNT()` trả về số hàng khớp với tiêu chí đã chỉ định.
<br />
###### SQL
```sql
SELECT COUNT(column_name)
FROM table_name
WHERE condition;
```
###### Cú pháp
Cú pháp trong `Linq` sẽ là:
<br />
```c#
from t in _db.GetAll<table_name>()
where condition
select column_name.Count()
```
##### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần trả về số hàng.</td>
  </tr>
  </tbody></table>
##### Ví dụ 1:
```c#
from p in _db.GetAll<PermissionsDb>()
where p.Type == "MENU"
select p.Count()
```
##### Ví dụ 2:
```c#
from p in _db.GetAll<PermissionsDb>()
where p.Type == "MENU"
select p.Id.Count()
```
##### Ví dụ 3:
```c#
from p in _db.GetAll<PermissionsDb>()
where p.Type == "MENU"
select 1.Count()
```
#### ➥ COUNT() OVER(PARTITION BY )
----------------------------------
##### SQL
```sql
SELECT
  order_id,
  order_date,
  customer_id,
  amount_paid,
 COUNT(*) OVER (PARTITION BY customer_id) AS orders_this_customer
FROM order
WHERE order_date >= '2023-01-01' AND order_date <= '2023-06-30';
```
##### Định nghĩa và cách sử dụng
Trong Oracle, chúng ta sử dụng riêng hàm `COUNT()` hoặc kết hợp với mệnh đề `GROUP BY` để đếm các hàng trong tập kết quả hoặc trong một nhóm hàng. `OVER()` và `PARTITION BY` áp dụng hàm `COUNT()` cho một nhóm hoặc các hàng được xác định bởi `PARTITION BY`.
<br />
Sự kết hợp của `COUNT()` và `OVER(PARTITION BY)` mạnh hơn việc chỉ sử dụng hàm `COUNT()` vì nó cho phép chúng ta lấy số hàng cho từng giá trị cụ thể của một cột.
<br />
Khi sử dụng `OVER()` và `PARTITION BY`, chúng ta không cần sử dụng mệnh đề `GROUP BY` để nhóm các bản ghi, điều này cho phép chúng ta có tập hợp kết quả ở cấp hàng. 
###### Cú pháp
`[table_name].[column_name].Count(() => new { [table_name].[column_name_partition_by] })`
<br />
<br />
Cú pháp trong `Linq` sẽ là:
<br />
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    count = 1.Count(() => new { t.column_name_partition_by })
}
```
##### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  <tr>
    <td><em>column_name_partition_by</em></td>
    <td>Tên các thuộc tính được map từ <em>COLUMN</em> để <em>PARTITION BY</em></td>
  </tr>
  </tbody></table>

### 🔸 Hàm SUM
-------------------------------------
#### ➥ SUM()
----------------------------------
##### Định nghĩa và cách sử dụng
Hàm `SUM()` trả về tổng của một cột số.
<br />
###### SQL
```sql
SELECT SUM(column_name)
FROM table_name
WHERE condition;
```
###### Cú pháp
Cú pháp trong `Linq` sẽ là:
<br />
```c#
from t in _db.GetAll<table_name>()
where condition
select column_name.Sum()
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần tính tổng.</td>
  </tr>
  </tbody></table>
##### Ví dụ :
```c#
from p in _db.GetAll<PermissionsDb>()
where p.Type == "MENU"
select p.Position.Sum()
```
#### ➥ SUM() OVER(PARTITION BY )
----------------------------------
##### SQL
```sql
SELECT
  emp_id,
  name,
  job,
  dept_id,
  salary,
  SUM(salary) OVER(PARTITION BY 1) AS total_salary
FROM employees;
```
##### Định nghĩa và cách sử dụng
Trong SQL, chúng ta sử dụng riêng hàm `SUM()` hoặc kết hợp với mệnh đề `GROUP BY` để tính tổng số giá trị của 1 cột trong tập kết quả hoặc trong một nhóm hàng. `OVER()` và `PARTITION BY` áp dụng hàm `SUM()` cho một nhóm hoặc các hàng được xác định bởi `PARTITION BY`.
<br />
Sự kết hợp của `SUM()` và `OVER(PARTITION BY)` mạnh hơn việc chỉ sử dụng hàm `SUM()` vì nó cho phép chúng ta lấy tổng số cho từng giá trị cụ thể của một cột.
<br />
Khi sử dụng `OVER()` và `PARTITION BY`, chúng ta không cần sử dụng mệnh đề `GROUP BY` để nhóm các bản ghi, điều này cho phép chúng ta có tập hợp kết quả ở cấp hàng. 
###### Cú pháp
`[table_name].[column_name].Sum(() => new { [table_name].[column_name_partition_by] })`
<br />
##### ➣ Trường hợp 1
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    sum = t.column_name.Sum(() => new { t.column_name_partition_by })
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần tính tổng.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  <tr>
    <td><em>column_name_partition_by</em></td>
    <td>Tên các thuộc tính được map từ <em>COLUMN</em> để <em>PARTITION BY</em></td>
  </tr>
  </tbody></table>
##### ➣ Trường hợp 2
Trường hợp với `PARTITION BY` = 1 thì tính tổng số giá trị của cột mà không cần nhóm theo `PARTITION BY`
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    sum = t.column_name.Sum(() => 1)
}
```

### 🔸 Hàm DISTINCT
---------------------------
#### Định nghĩa và cách sử dụng
Câu lệnh `SELECT DISTINCT` được sử dụng để chỉ trả về các giá trị riêng biệt (khác nhau).
##### SQL
```sql
SELECT DISTINCT column1, column2, ...
FROM table_name;
```
##### Cú pháp
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    column_name = t.column_name.Distinct()
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần trả về các giá trị riêng biệt (khác nhau).</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>

### 🔸 Hàm TRUNC
---------------------------
#### Định nghĩa và cách sử dụng
Hàm `TRUNC` trả về ngày đầu vào được cắt bớt thành một phần ngày được chỉ định.
##### SQL
```sql
TRUNC ( date, datepart )
```
##### Cú pháp
##### ➣ Trường hợp 1
Không có `datepart`
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    column_name = t.column_name.Trunc()
}
```
##### ➣ Trường hợp 2
Có `datepart`
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    column_name = t.column_name.Trunc(datepart)
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần truncate.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  <tr>
    <td><em>datepart</em></td>
    <td>Chỉ định độ chính xác cho việc cắt ngắn. Bảng này liệt kê tất cả các giá trị ngày tháng hợp lệ cho DATETRUNC, vì đó cũng là một phần hợp lệ của loại ngày đầu vào.</td>
  </tr>
  </tbody></table>
###### Mô tả datepart
`datepart` được định nghĩa thông qua kiểu `enum` là `TruncateType`
<table class="ws-table-all notranslate">
    <tbody><tr>
            <th><em>datepart</em></th>
            <th>Format Model</th>
            <th>Rounding or Truncating Unit</th>
        </tr>
        <tr>
            <td>TruncateType.Year</td>
            <td>YEAR</td>
            <td>Year (rounds up on July 1)</td>
        </tr>
        <tr>
            <td>TruncateType.Quarter</td>
            <td>Q</td>
            <td>Quarter (rounds up on the sixteenth day of the second month of the quarter)</td>
        </tr>
        <tr>
            <td>TruncateType.Month</td>
            <td>MONTH</td>
            <td>Month (rounds up on the sixteenth day)</td>
        </tr>
        <tr>
            <td>TruncateType.DayOfYear</td>
            <td>WW</td>
            <td>Same day of the week as the first day of the year</td>
        </tr>
        <tr>
            <td>TruncateType.DayOfMonth</td>
            <td>W</td>
            <td>Same day of the week as the first day of the month</td>
        </tr>
        <tr>
            <td>TruncateType.Day</td>
            <td>DDD</td>
            <td>Day</td>
        </tr>
        <tr>
            <td>TruncateType.DayOfWeek</td>
            <td>DAY</td>
            <td>Starting day of the week</td>
        </tr>
        <tr>
            <td>TruncateType.Hour</td>
            <td>HH</td>
            <td>Hour</td>
        </tr>
        <tr>
            <td>TruncateType.Minute</td>
            <td>MI</td>
            <td>Minute</td>
        </tr>
    </tbody></table> 

### 🔸 Hàm ROW_NUMBER
---------------------------
#### Định nghĩa và cách sử dụng
Đánh số đầu ra của một tập kết quả. Cụ thể hơn, trả về số thứ tự của một hàng trong một phân vùng của tập kết quả, bắt đầu từ 1 cho hàng đầu tiên trong mỗi phân vùng.
##### SQL
```sql
ROW_NUMBER ( )   
    OVER ( [ PARTITION BY value_expression , ... [ n ] ] order_by_clause )
```
##### Cú pháp
##### ➣ Trường hợp 1 
Không nhóm theo phân vùng `PARTITION BY`
###### ☛ Sắp xếp theo 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => t.order_by_column)
}
```
###### ☛ Sắp xếp theo nhiều cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => new { t.order_by_column, ... [ n ] })
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>order_by_column</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để sắp xếp. Nếu muốn sắp xếp theo giảm dần (<code>Descending</code>) thì thêm cú pháp <code>.Desc()</code> vào cuối.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>
###### Cú pháp cho trường hợp sắp xếp giảm dần của 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => t.order_by_column.Desc())
}
```

##### ➣ Trường hợp 2 
Sắp xếp theo nhóm phân vùng `PARTITION BY`
###### ☛ Nhóm theo 1 cột và sắp xếp theo 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => t.partition_by_column, () => t.order_by_column)
}
```
###### ☛ Nhóm theo 1 cột và sắp xếp theo nhiều cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => t.partition_by_column, () => new { t.order_by_column1, ... [ n ] })
}
```
###### ☛ Nhóm theo nhiều cột và sắp xếp theo 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => new { t.partition_by_column, ... [ n ] }, () => t.order_by_column)
}
```
###### ☛ Nhóm theo nhiều cột và sắp xếp theo nhiều cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    rownum = t.RowNumber(() => new { t.partition_by_column, ... [ n ] }, () => new { t.order_by_column, ... [ n ] })
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>partition_by_column</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để nhóm thành các phân vùng.</td>
  </tr>
  <tr>
    <td><em>order_by_column</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để sắp xếp theo từng phân vùng. Nếu muốn sắp xếp theo giảm dần (<code>Descending</code>) thì thêm cú pháp <code>.Desc()</code> vào cuối.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>
  
### 🔸 Hàm GROUP BY
---------------------------
#### Định nghĩa và cách sử dụng
Câu lệnh `GROUP BY` nhóm các hàng có cùng giá trị thành các hàng tóm tắt, chẳng hạn như "tìm số lượng khách hàng ở mỗi quốc gia".

Câu lệnh `GROUP BY` thường được sử dụng với các hàm tổng hợp (`COUNT(), MAX(), MIN(), SUM(), AVG()`) để nhóm tập kết quả theo một hoặc nhiều cột.
##### SQL
```sql
SELECT column_name(s)
FROM table_name
WHERE condition
GROUP BY column_name(s);
```
##### Cú pháp
###### ☛ Nhóm theo 1 cột
```c#
(
  from t in _db.GetAll<table_name>()
  where condition 
  select new {
    t.column_name
  }
).Groupby(gr => gr.column_name)
```
###### ☛ Nhóm theo nhiều cột
```c#
(
  from t in _db.GetAll<table_name>()
  where condition 
  select new {
    t.column_name,
    ...
    [ n ]
  }
).Groupby(gr => 
  new {
    gr.column_name,
    ...
    [ n ]
  })
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để nhóm.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>
  

### 🔸 Hàm UNION
---------------------------
#### Định nghĩa và cách sử dụng
Toán tử `UNION` được sử dụng để kết hợp tập kết quả của hai hoặc nhiều câu lệnh `SELECT`.

• Mọi câu lệnh `SELECT` trong `UNION` phải có cùng số cột
• Các cột cũng phải có kiểu dữ liệu tương tự
• Các cột trong mỗi câu lệnh `SELECT` cũng phải có cùng thứ tự
#### ✦ Sử dụng UNION 
##### SQL
```sql
SELECT column_name(s) FROM table1
UNION
SELECT column_name(s) FROM table2;
```
##### Cú pháp
```c#
(
  from t1 in _db.GetAll<table1>()
  where condition
  select new {
      t1.column_name(s)
  }).Union(
  from t2 in _db.GetAll<table2>()
  where condition
  select new {
      t2.column_name(s)
  }
)
```
#### ✦ Sử dụng UNION ALL 
Toán tử `UNION` chỉ chọn các giá trị riêng biệt theo mặc định. Để cho phép các giá trị trùng lặp, hãy sử dụng `UNION ALL`:
##### SQL
```sql
SELECT column_name(s) FROM table1
UNION ALL
SELECT column_name(s) FROM table2;
```
##### Cú pháp
```c#
(
  from t1 in _db.GetAll<table1>()
  where condition
  select new {
      t1.column_name(s)
  }).UnionAll(
  from t2 in _db.GetAll<table2>()
  where condition
  select new {
      t2.column_name(s)
  }
)
```
#### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table1</em></td>
    <td>Bắt buộc. Tên object của <em>TABLE 1</em> được map từ DB.</td>
  </tr> 
  <tr>
    <td><em>table2</em></td>
    <td>Bắt buộc. Tên object của <em>TABLE 2</em> được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để kết hợp từ <em>TABLE 1</em> và <em>TABLE 2</em>.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>


### 🔸 Hàm LISTAGG
---------------------------
#### Định nghĩa và cách sử dụng
Nối các giá trị của biểu thức chuỗi và đặt các giá trị phân cách giữa chúng. Dấu phân cách không được thêm vào cuối chuỗi.
##### SQL
```sql
LISTAGG(measure_expr [, 'delimiter']) 
    WITHIN GROUP (order_by_clause) [OVER query_partition_clause]
```
##### Cú pháp
##### ➣ Trường hợp 1 
Không nhóm theo phân vùng `PARTITION BY`
###### ☛ Sắp xếp theo 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => t.order_by_column)
}
```
###### ☛ Sắp xếp theo nhiều cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => new { t.order_by_column, ... [ n ] })
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để nối.</td>
  </tr>
  <tr>
    <td><em>separator</em></td>
    <td>Bắt buộc. Là chuỗi hoặc ký tự được sử dụng làm dấu phân cách cho các chuỗi được nối.</td>
  </tr>
  <tr>
    <td><em>order_by_column</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để sắp xếp. Nếu muốn sắp xếp theo giảm dần (<code>Descending</code>) thì thêm cú pháp <code>.Desc()</code> vào cuối.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>

###### Cú pháp cho trường hợp sắp xếp giảm dần của 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => t.order_by_column.Desc())
}
```

##### ➣ Trường hợp 2 
Sắp xếp theo nhóm phân vùng `PARTITION BY`
###### ☛ Nhóm theo 1 cột và sắp xếp theo 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => t.order_by_column, () => t.partition_by_column)
}
```
###### ☛ Nhóm theo 1 cột và sắp xếp theo nhiều cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => new { t.order_by_column1, ... [ n ] }, () => t.partition_by_column)
}
```
###### ☛ Nhóm theo nhiều cột và sắp xếp theo 1 cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => t.order_by_column, () => new { t.partition_by_column, ... [ n ] })
}
```
###### ☛ Nhóm theo nhiều cột và sắp xếp theo nhiều cột
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    agg = t.column_name.LISTAGG(separator, () => new { t.order_by_column, ... [ n ] }, () => new { t.partition_by_column, ... [ n ] })
}
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để nối.</td>
  </tr>
  <tr>
    <td><em>separator</em></td>
    <td>Bắt buộc. Là chuỗi hoặc ký tự được sử dụng làm dấu phân cách cho các chuỗi được nối.</td>
  </tr>
  <tr>
    <td><em>order_by_column</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để sắp xếp theo từng phân vùng. Nếu muốn sắp xếp theo giảm dần (<code>Descending</code>) thì thêm cú pháp <code>.Desc()</code> vào cuối.</td>
  </tr>
  <tr>
    <td><em>partition_by_column</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> dùng để nhóm thành các phân vùng.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định</td>
  </tr>
  </tbody></table>

---
## 📌 Các hàm trong Linq
### 🔸 Hàm IfGenerateQuery()
-----------------------------------
#### Định nghĩa và cách sử dụng
Dùng `IfGenerateQuery()` để hiển thị câu SQL theo tiêu chí đã chỉ định
#### Cú pháp
##### ➣ Trường hợp 1
```c#
from t in _db.GetAll<table_name>()
where condition.IfGenerateQuery(condition_to_show)
select t
```
###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Tiêu chí chỉ định của câu lệnh select</td>
  </tr>
  <tr>
    <td><em>condition_to_show</em></td>
    <td>Tiêu chí chỉ định để hiển thị câu lệnh của condition</td>
  </tr>
  </tbody></table>
  
##### ➣ Trường hợp 2
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    column_name = t.column_name.IfGenerateQuery(condition_to_show)
    ...
}
```

###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Tiêu chí chỉ định của câu lệnh select</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần lấy.</td>
  </tr>
  <tr>
    <td><em>condition_to_show</em></td>
    <td>Tiêu chí chỉ định để lấy ra <em>column_name</em></td>
  </tr>
  </tbody></table>


### 🔸 Hàm IfSelectQuery()
-----------------------------------
#### Định nghĩa và cách sử dụng
Dùng `IfSelectQuery()` để hiển thị câu SQL theo tiêu chí đã chỉ định
#### Cú pháp
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    column_name = condition_to_show.IfSelectQuery(if_true, if_false)
    ...
}
```

###### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Tiêu chí chỉ định của câu lệnh select</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính cần lấy.</td>
  </tr>
  <tr>
    <td><em>condition_to_show</em></td>
    <td>Tiêu chí chỉ định để lấy ra <em>column_name</em></td>
  </tr>
  <tr>
    <td><em>if_true</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần lấy nếu condition_to_show = true.</td>
  </tr>
  <tr>
    <td><em>if_false</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần lấy nếu condition_to_show = false.</td>
  </tr>
  </tbody></table>

### 🔸 Hàm HaveIfTrue()
-----------------------------------
#### Định nghĩa và cách sử dụng
Dùng `HaveIfTrue()` để hiển thị câu SQL Join theo tiêu chí đã chỉ định
#### Cú pháp
```c#
from t1 in _db.GetAll<table_name1>()
join t2 in _db.GetAll<table_name2>().HaveIfTrue(condition_to_show) on table_name1.PK equals table_name2.FK
where condition
select selector
```

###### Parameter Values

|Parameter                   |Description                    |
|----------------------------|-------------------------------|
|*condition_to_show*         |Điều kiện để xuất hiện đoạn JOIN TABLE table_name2|
|*selector*|Bắt buộc. Giá trị cần lấy ra|

###### Ví dụ
```c#
from tran in _db.GetAll<TransactionDb>()
join u in _db.GetAll<UsersDb>().HaveIfTrue(groupByNhanVien) on tran.UserId equals u.Id
...
```
> Trong ví dụ trên, chỉ khi `groupByNhanVien` = true thì đoạn SQL join với bảng `USERS` mới được xuất hiện trong SQL output



### 🔸 Hàm ForUpdateSkipLocked()
-----------------------------------
#### Định nghĩa và cách sử dụng
`ForUpdateSkipLocked()` được gắn trực tiếp vào `IQueryable` để sinh câu lệnh Oracle:

```sql
FOR UPDATE SKIP LOCKED
```

Hàm này thường dùng trong các worker xử lý song song để **claim** một nhóm bản ghi chưa xử lý. Những dòng đã bị transaction khác khóa sẽ được Oracle bỏ qua, nhờ đó nhiều worker có thể cùng đọc một bảng mà không lấy trùng cùng một bản ghi.

Dữ liệu được thực thi bằng các overload `ToListAsync(...)` thông thường của `IDbSession`; không cần sử dụng một hàm select khóa riêng.

#### Các overload

```csharp
IQueryable<TSource> ForUpdateSkipLocked<TSource>(
    this IQueryable<TSource> source);

IQueryable<TSource> ForUpdateSkipLocked<TSource, TLocked>(
    this IQueryable<TSource> source,
    Expression<Func<TSource, TLocked>> locked);

IQueryable<TSource> ForUpdateSkipLocked<TSource>(
    this IQueryable<TSource> source,
    int take);

IQueryable<TSource> ForUpdateSkipLocked<TSource, TLocked>(
    this IQueryable<TSource> source,
    int take,
    Expression<Func<TSource, TLocked>> locked);
```

##### Parameter Values

| Parameter | Description |
|---|---|
| `source` | Bắt buộc. Truy vấn `IQueryable<TSource>` cần khóa dữ liệu. |
| `take` | Không bắt buộc. Số dòng tối đa cần lấy và khóa trong một lần xử lý. Giá trị phải lớn hơn `0`. |
| `locked` | Không bắt buộc. Biểu thức chỉ định các cột trong mệnh đề `FOR UPDATE OF ... SKIP LOCKED`. |
| `transaction` | Transaction truyền vào `ToListAsync`. Cần giữ transaction mở trong toàn bộ thời gian xử lý các dòng đã claim. |

#### Lấy một batch và khóa toàn bộ dòng

```csharp
await using var scope = await _db.BeginScopeAsync();
var transaction = scope.Transaction;

var query = _db.GetAll<UpdateNewMadonviDb>()
    .Where(x => x.TrangThai == MadonviProcessStatus.Pending
                && x.RetryCount < options.MaxRetry)
    .OrderBy(x => x.CreateDate)
    .ThenBy(x => x.MadonviCu)
    .ForUpdateSkipLocked(chunkSize);

var rows = await _db.ToListAsync<UpdateNewMadonviDb>(
    transaction,
    query,
    ct: cancellationToken);

foreach (var row in rows)
{
    // Xử lý và cập nhật trạng thái trong cùng transaction.
}

await scope.CommitAsync(cancellationToken);
```

SQL được sinh theo dạng:

```sql
SELECT x."MADONVI_CU",
       x."MADONVI_MOI",
       x."MACOQUAN",
       x."MAIVAN",
       x."TRANG_THAI",
       x."CREATE_DATE",
       x."UPDATE_DATE",
       x."RETRY_COUNT",
       x."ERROR_MESSAGE",
       x."PROCESS_TOKEN",
       x."PROCESS_DATE"
FROM UPDATE_NEW_MADONVI x
WHERE x."TRANG_THAI" = :p1
  AND x."RETRY_COUNT" < :p2
ORDER BY x."CREATE_DATE",
         x."MADONVI_CU"
FOR UPDATE SKIP LOCKED
```

Giới hạn `chunkSize` được `ToListAsync` lấy từ expression `ForUpdateSkipLocked(chunkSize)` và áp dụng trong quá trình fetch dữ liệu. SQL không sử dụng inline view `q_take`, `ROWNUM` hoặc `FETCH FIRST`, tránh lỗi Oracle:

```text
ORA-02014: cannot select FOR UPDATE from view with DISTINCT, GROUP BY, etc.
```

#### Chỉ định các cột cần khóa

```csharp
var query = _db.GetAll<UpdateNewMadonviDb>()
    .Where(x => x.TrangThai == MadonviProcessStatus.Pending)
    .OrderBy(x => x.CreateDate)
    .ThenBy(x => x.MadonviCu)
    .ForUpdateSkipLocked(
        chunkSize,
        x => new
        {
            x.MadonviCu,
            x.MadonviMoi,
            x.Macoquan,
            x.Maivan
        });

var rows = await _db.ToListAsync<UpdateNewMadonviDb>(
    transaction,
    query,
    ct: cancellationToken);
```

SQL cuối câu truy vấn sẽ có dạng:

```sql
FOR UPDATE OF x."MADONVI_CU",
              x."MADONVI_MOI",
              x."MACOQUAN",
              x."MAIVAN"
SKIP LOCKED
```

#### Lấy và khóa một dòng

Thay cho API lấy một dòng riêng, truyền `take = 1`:

```csharp
var query = _db.GetAll<UpdateNewMadonviDb>()
    .Where(x => x.TrangThai == MadonviProcessStatus.Pending)
    .OrderBy(x => x.CreateDate)
    .ThenBy(x => x.MadonviCu)
    .ForUpdateSkipLocked(1);

var rows = await _db.ToListAsync<UpdateNewMadonviDb>(
    transaction,
    query,
    ct: cancellationToken);

var item = rows.FirstOrDefault();
```

#### Không giới hạn số dòng

Có thể dùng overload không có `take`:

```csharp
var rows = await _db.ToListAsync<UpdateNewMadonviDb>(
    transaction,
    _db.GetAll<UpdateNewMadonviDb>()
        .Where(x => x.TrangThai == MadonviProcessStatus.Pending)
        .OrderBy(x => x.CreateDate)
        .ForUpdateSkipLocked(),
    ct: cancellationToken);
```

Cách này sẽ fetch toàn bộ các dòng phù hợp mà chưa bị transaction khác khóa. Với bảng queue hoặc bảng theo dõi có nhiều dữ liệu, nên ưu tiên overload có `take`.

#### Quy tắc sử dụng

- Đặt `ForUpdateSkipLocked(...)` ở cuối chuỗi LINQ, sau `Where`, `OrderBy` và `ThenBy`.
- Khi đã dùng `ForUpdateSkipLocked(chunkSize)`, **không gọi thêm `.Take(chunkSize)`**. `Take()` có thể sinh inline view và làm Oracle báo `ORA-02014`.
- Luôn truyền transaction vào `ToListAsync` để việc khóa và cập nhật dữ liệu nằm trong cùng một transaction.
- Chỉ `Commit` sau khi các dòng đã claim được cập nhật thành công.
- Khi xử lý lỗi, thực hiện `Rollback` hoặc để scope bị dispose mà không commit.
- Nên có `OrderBy` ổn định để nhiều worker ưu tiên bản ghi theo cùng một thứ tự nghiệp vụ.
- Không dùng `Distinct`, `GroupBy`, phép tổng hợp hoặc projection không thể cập nhật trong truy vấn cần `FOR UPDATE`.
- Không giữ transaction mở trong lúc gọi API ngoài hoặc xử lý kéo dài nếu không thật sự cần thiết, vì các dòng vẫn bị khóa cho đến khi transaction kết thúc.

#### Chuyển đổi từ API cũ

Không dùng:

```csharp
var rows = await _db.SelectForUpdateSkipLockedAsync(
    transaction,
    query.Take(chunkSize),
    ct: cancellationToken);
```

Dùng:

```csharp
var rows = await _db.ToListAsync<UpdateNewMadonviDb>(
    transaction,
    query.ForUpdateSkipLocked(chunkSize),
    ct: cancellationToken);
```

Tương tự, thay `FirstOrDefaultForUpdateSkipLockedAsync(...)` bằng `ForUpdateSkipLocked(1)` kết hợp với `rows.FirstOrDefault()`.

### 🔸 Hàm ToDate()
------------------------
#### Định nghĩa và cách sử dụng
Chuyển đổi giá trị là chuỗi hoặc số sang kiểu dữ liệu `DateTime` trong C#
#### Cú pháp
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    Date = t.column_name.ToDate(format)
}
```
#### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định của câu lệnh select</td>
  </tr>
  <tr>
    <td><em>column_name</em></td>
    <td>Bắt buộc. Tên thuộc tính được map từ <em>COLUMN</em> cần lấy.</td>
  </tr>
  <tr>
    <td><em>format</em></td>
    <td>Bắt buộc. Định dạng thời gian của <em>column_name</em> đang lưu để chuyển đổi sang kiểu <code>DateTime</code><ul>
<li><strong>d:</strong> Represents the day of the month as a number from 1 through 31.</li>
<li><strong>dd:</strong> Represents the day of the month as a number from 01 through 31.</li>
<li><strong>ddd:</strong> Represents the abbreviated name of the day (Mon, Tues, Wed, etc).</li>
<li><strong>dddd:</strong> Represents the full name of the day (Monday, Tuesday, etc).</li>
<li><strong>h: </strong>12-hour clock hour (e.g. 4).</li>
<li><strong>hh:</strong> 12-hour clock, with a leading 0 (e.g. 06)</li>
<li><strong>H:</strong> 24-hour clock hour (e.g. 15)</li>
<li><strong>HH:</strong> 24-hour clock hour, with a leading 0 (e.g. 22)</li>
<li><strong>m:</strong> Minutes</li>
<li><strong>mm:</strong> Minutes with a leading zero</li>
<li><strong>M:</strong> Month number(eg.3)</li>
<li><strong>MM:</strong> Month number with leading zero(eg.04)</li>
<li><strong>MMM:</strong> Abbreviated Month Name (e.g. Dec)</li>
<li><strong>MMMM:</strong> Full month name (e.g. December)</li>
<li><strong>s:</strong> Seconds</li>
<li><strong>ss:</strong> Seconds with leading zero</li>
<li><strong>t: </strong>Abbreviated AM / PM (e.g. A or P)</li>
<li><strong>tt:</strong> AM / PM (e.g. AM or PM</li>
<li><strong>y:</strong> Year, no leading zero (e.g. 2015 would be 15)</li>
<li><strong>yy:</strong> Year, leading zero (e.g. 2015 would be 015)</li>
<li><strong>yyy:</strong> Year, (e.g. 2015)</li>
<li><strong>yyyy:</strong> Year, (e.g. 2015)</li>
<li><strong>K:</strong> Represents the time zone information of a date and time value (e.g. +05:00)</li>
<li><strong>z:</strong> With DateTime values represent the signed offset of the local operating system's time zone from<br>
Coordinated Universal Time (UTC), measured in hours. (e.g. +6)</li>
<li><strong>zz:</strong> As z, but with leading zero (e.g. +06)</li>
<li><strong>zzz:</strong> With DateTime values represents the signed offset of the local operating system's time zone from UTC, measured in hours and minutes. (e.g. +06:00)</li>
<li><strong>f:</strong> Represents the most significant digit of the seconds fraction; that is, it represents the tenths of a second in a date and time value.</li>
<li><strong>ff:</strong> Represents the two most significant digits of the second's fraction in date and time</li>
<li><strong>fff:</strong> Represents the three most significant digits of the second's fraction; that is, it represents the milliseconds in a date and time value.</li>
<li><strong>ffff:</strong> Represents the four most significant digits of the second's fraction; that is, it represents the ten-thousandths of a second in a date and time value. While it is possible to display the ten thousandths of a second component of a time value, that value may not be meaningful.</li>
<li><strong>fffff:</strong> Represents the five most significant digits of the second's fraction; that is, it represents the hundred-thousandths of a second in a date and time value.</li>
<li><strong>ffffff:</strong> Represents the six most significant digits of the second's fraction; that is, it represents the millionths of a second in a date and time value.</li>
<li><strong>fffffff:</strong> Represents the seven most significant digits of the second's fraction; that is, it represents the ten-millionths of a second in a date and time value.</li>
</ul></td>
  </tr>
  </tbody></table>

#### Ví dụ
```c#
from t in _db.GetAll<TestDb>()
where t.Id == 1
select new 
{
    Date = t.DateString.ToDate("yyyyMMdd"),
    Date2 = t.DateNumber.ToDate("yyyyMM")
};
```

### 🔸 Hàm Sequence
------------------------
#### Định nghĩa và cách sử dụng
Lấy giá trị tiếp của `SEQUENCE` trong database
#### Cú pháp
```c#
from t in _db.GetAll<table_name>()
where condition
select new {
    Id = (sequence_name).Sequence<TKey>()
}
```
##### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Tiêu chí chỉ định của câu lệnh select</td>
  </tr>
  <tr>
    <td><em>sequence_name</em></td>
    <td>Bắt buộc. Tên <em>SEQUENCE</em> sẽ gọi để lấy giá trị tiếp theo.</td>
  </tr>
  <tr>
    <td><em>TKey</em></td>
    <td>Bắt buộc. Kiểu trả về của giá trị <em>SEQUENCE</em>.</td>
  </tr>
  </tbody></table>

  
### 🔸 Hàm ConnectBy
------------------------
#### Định nghĩa và cách sử dụng
Lấy ra danh sách tự truy vấn cha con trong database.
<br />
> **Lưu ý**: Hàm này bắt buộc phải có cấu hình `COLUMN_NAME` cho các đối tượng cha con


#### SQL
Ví dụ dưới đây có mệnh đề `START WITH` để chỉ định hàng gốc cho hệ thống phân cấp.
<br />
eg:
```sql
SELECT last_name, employee_id, manager_id, LEVEL
      FROM employees
      START WITH employee_id = 100
      CONNECT BY PRIOR employee_id = manager_id;
```
#### Cú pháp
```c#
from t in _db.GetAll<table_name>() 
where t.ConnectBy(t.start_column, start_value, x => condition)
select selector  
```
##### Parameter Values
<table class="ws-table-all notranslate"> 
  <tbody><tr>
    <th style="width:23%">Parameter</th>
    <th>Description</th>  </tr>  
  <tr>
    <td><em>table_name</em></td>
    <td>Bắt buộc. Tên object được map từ DB.</td>
  </tr>
  <tr>
    <td><em>start_column</em></td>
    <td>Bắt buộc. <em>COLUMN</em> làm điều kiện so sánh trong mệnh đề <code>START WITH</code></td>
  </tr>
  <tr>
    <td><em>start_value</em></td>
    <td>Bắt buộc. Giá trị so sánh trong mệnh đề <code>START WITH</code></td>
  </tr>
  <tr>
    <td><em>condition</em></td>
    <td>Bắt buộc. Điều kiện để liên kết cha con trong mệnh đề <code>CONNECT BY PRIOR</code>
    <br />Ví dụ:<ol>
    <li><code>x => x.parentId == x.Id</code></li>
    <li><code>x => x.parentId == x.Id && x.status > 0</code></li>
    </ol></td>
  </tr>
  <tr>
    <td><em>selector</em></td>
    <td>Bắt buộc. Giá trị cần lấy ra</td>
  </tr>
  </tbody></table>

#### Ví dụ
```c#
from c in _dbTNHS.GetAll<DmCoQuanToChucDb>()
where c.ConnectBy(c.Id, 4823, x => x.chaId == x.Id)
select new
{
    c.Id,
    c.cap,
    c.chaId
}
```
> Nếu muốn đặt `PRIOR` bên vế nào thì thêm `.Prior()` bên vế đấy
> <br> Ví dụ để `CONNECT BY chaId = PRIOR id`
>  ```c#
> from c in _dbTNHS.GetAll<DmCoQuanToChucDb>()
> where c.ConnectBy(c.Id, 4823, x => x.chaId == x.Id.Prior())
> select new
> {
>     c.Id,
>     c.cap,
>     c.chaId
> }
> ```

### 🔸 Hàm ConnectByRoot
------------------------
#### Định nghĩa và cách sử dụng
* Chỉ được dùng khi có hàm [**`ConnectBy`**](#-hàm-connectby).
* Dùng để lấy tập hợp dữ liệu cấp cao nhất trong cây dữ liệu được lấy ra từ [**`ConnectBy`**](#-hàm-connectby).

#### Cú pháp
```c#
from t in _db.GetAll<table_name>() 
where t.ConnectBy(t.start_column, start_value, x => condition)
select new {
  ancestor = t.column_name.ConnectByRoot(),
  t.column_name,
  ...
}  
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` cần lấy. ( với ancestor sẽ là giá trị cấp cha cao nhất của `column_name`)|

### 🔸 Hàm InArray
------------------------

#### Định nghĩa và cách sử dụng

Mục đích sủ dụng giống như với `Any` --> kiểm tra một giá trị có nằm bên trong một tập hợp các giá trị hay không, nếu đúng thì trả về TRUE, ngược lại trả về FALSE. Thường dùng cho trường hợp danh sách so sánh hơn 1000 phần tử (với `IN` chỉ được truyền vào tối đa 1000 parameter).

#### Cú pháp
```c#
from t in _db.GetAll<table_name>() 
where arrays.InArray(column, hintCardinality)
select selector  
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*arrays*|Bắt buộc. List hoặc Array của các giá trị để kiểm tra với `column`.|
|*column*|Bắt buộc. Column cần so sánh.|
|*hintCardinality*| Có gắn hint CARDINALITY cho biểu thức `SELECT COLUMN_VALUE FROM TABLE()` không (chỉ có tác dụng cho Oracle 12 trở lên).|
|*selector*|Bắt buộc. Giá trị cần lấy ra|

#### Cấu hình Oracle từ phiên bản 12 trở lên

Khi sử dụng `InArray` với Oracle 12c trở lên, cần tạo các collection type bên dưới trong schema mà ứng dụng kết nối tới. Chạy script này một lần trước khi sử dụng `InArray`:

```sql
CREATE OR REPLACE TYPE NUM_LIST_T AS TABLE OF NUMBER;
/

-- VARCHAR2 list
CREATE OR REPLACE TYPE VARCHAR2_LIST_T AS TABLE OF VARCHAR2(4000);
/

-- DATE list  (nếu dùng TIMESTAMP thì tạo thêm TIMESTAMP_LIST_T)
CREATE OR REPLACE TYPE DATE_LIST_T AS TABLE OF DATE;
/

-- RAW(16) list (để map GUID)
CREATE OR REPLACE TYPE RAW16_LIST_T AS TABLE OF RAW(16);
```

#### Ví dụ
```c#
from dv in _dbTNHS.GetAll<DmDonviDb>()
where dv.SuDung == 1
&& cqtcIds.InArray(dv.dmCoQuanToChucId, true)
select new
{
    dv.Id,
    dv.Ma,
    dv.Ten
}
```


### 🔸 Hàm XMLTableOfNumber
------------------------

#### Định nghĩa và cách sử dụng
Mục đích sủ dụng giống như với `Any` --> `IN` nhưng bắt nguồn từ 1 cây dạng XML.


#### Cú pháp
```c#
from t in _db.GetAll<table_name>() 
where xml_input.XMLTableOfNumber(path_parent, path_value)
select selector  
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*xml_input*|`XmlDocument` của cây xml đầu vào.<br>( *sử dụng hàm [`ConvertToXml`](#-h%C3%A0m-converttoxml) để sinh ra `XmlDocument`* )|
|*path_parent*|Path xml đến node cha của list node chứa giá trị cần so sánh.<br>Nếu dùng hàm [`ConvertToXml`](#-h%C3%A0m-converttoxml) để sinh ra `XmlDocument`:<br> Ví dụ:<br> <pre><code>var xmlCqtc = new { coquan = coQuans.Select(x => x.Id).ToList() }.ConvertToXml();</code></pre>thì `path_parent` sẽ là `"/root/coquan"`|
|*path_value*|Path xml từ node cha đến node chứa giá trị cần so sánh.<br>Nếu dùng hàm [`ConvertToXml`](#-h%C3%A0m-converttoxml) để sinh ra `XmlDocument` thì `path_value` thường sẽ là `"/"`.
|*selector*|Bắt buộc. Giá trị cần lấy ra|

#### Ví dụ
```c#
var xmlCqtc = new { coquan = coQuans.Select(x => x.Id).ToList() }.ConvertToXml();
from dv in _dbTNHS.GetAll<DmDonviDb>()
where dv.SuDung == 1
&& xmlCqtc.XMLTableOfNumber("/root/coquan", "/").Any(x => x == dv.dmCoQuanToChucId)
select new
{
    dv.Id,
    dv.Ma,
    dv.Ten
}
```


### 🔸 Hàm RegexpReplace
------------------------
#### Định nghĩa và cách sử dụng
Dùng hàm `RegexpReplace()` trong LINQ để sinh ra hàm Oracle `REGEXP_REPLACE(source, pattern, replacement [, match_parameter])`.

Hàm này phù hợp khi cần chuẩn hoá chuỗi ngay trong SQL, ví dụ:
- loại bỏ ký tự đặc biệt
- bỏ khoảng trắng thừa
- chuẩn hoá mã hồ sơ, số bưu điện, mã đơn vị
- thay thế theo biểu thức chính quy thay vì `REPLACE` thông thường

#### Cú pháp
##### ➣ Trường hợp 1: 3 tham số
```csharp
from t in _db.GetAll<table_name>()
where condition
select new
{
    value = t.column_name.RegexpReplace(pattern, replacement)
}
```

##### ➣ Trường hợp 2: có `matchParameter`
```csharp
from t in _db.GetAll<table_name>()
where condition
select new
{
    value = t.column_name.RegexpReplace(pattern, replacement, matchParameter)
}
```

#### SQL tương đương
```sql
REGEXP_REPLACE(column_name, pattern, replacement)
REGEXP_REPLACE(column_name, pattern, replacement, match_parameter)
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` nguồn.|
|*pattern*|Bắt buộc. Biểu thức chính quy để tìm kiếm.|
|*replacement*|Bắt buộc. Chuỗi thay thế. Có thể là chuỗi rỗng nếu muốn xoá phần khớp.|
|*matchParameter*|Không bắt buộc. Tuỳ chọn Oracle regex như `i`, `c`, `n`, `m`, `x`.|

#### Ví dụ
```csharp
from h in _db.GetAll<HosoDb>()
select new
{
    h.Id,
    SoBuuDienNorm = h.SoBuuDien.RegexpReplace("[^0-9A-Za-z]", "")
}
```

> Truy vấn trên sẽ sinh ra `REGEXP_REPLACE(h.SoBuuDien, '[^0-9A-Za-z]', '')`.

### 🔸 Hàm RegexpLike
------------------------
#### Định nghĩa và cách sử dụng
Dùng hàm `RegexpLike()` trong LINQ để sinh ra điều kiện Oracle `REGEXP_LIKE(...)`.

Đây là hàm dùng tốt nhất trong `where`, `Any`, `Exists`, hoặc các biểu thức điều kiện. Thường dùng khi:
- kiểm tra chuỗi chỉ gồm số
- kiểm tra định dạng mã hồ sơ
- kiểm tra chuỗi có ký tự đặc biệt hay không
- lọc dữ liệu theo mẫu phức tạp

#### Cú pháp
##### ➣ Trường hợp 1: 2 tham số
```csharp
from t in _db.GetAll<table_name>()
where t.column_name.RegexpLike(pattern)
select t
```

##### ➣ Trường hợp 2: có `matchParameter`
```csharp
from t in _db.GetAll<table_name>()
where t.column_name.RegexpLike(pattern, matchParameter)
select t
```

#### SQL tương đương
```sql
REGEXP_LIKE(column_name, pattern)
REGEXP_LIKE(column_name, pattern, match_parameter)
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` cần kiểm tra.|
|*pattern*|Bắt buộc. Biểu thức chính quy dùng để so khớp.|
|*matchParameter*|Không bắt buộc. Tuỳ chọn Oracle regex như `i`, `c`, `n`, `m`, `x`.|

#### Ví dụ
```csharp
from h in _db.GetAll<HosoDb>()
where h.SoHoSo.RegexpLike("^[0-9]+$")
select h
```

```csharp
from h in _db.GetAll<HosoDb>()
where h.Ten.RegexpLike("anh", "i")
select h
```

### 🔸 Hàm RegexpInstr
------------------------
#### Định nghĩa và cách sử dụng
Dùng hàm `RegexpInstr()` trong LINQ để sinh ra hàm Oracle `REGEXP_INSTR(...)`.

Hàm này trả về vị trí xuất hiện của chuỗi con khớp với biểu thức chính quy trong chuỗi nguồn. Phù hợp khi:
- cần biết chuỗi khớp từ vị trí nào
- dùng trong `select new { ... }`
- kết hợp điều kiện `> 0` để kiểm tra có xuất hiện hay không

#### Cú pháp
##### ➣ Trường hợp 1: chỉ có `pattern`
```csharp
from t in _db.GetAll<table_name>()
select new
{
    pos = t.column_name.RegexpInstr(pattern)
}
```

##### ➣ Trường hợp 2: đầy đủ tham số
```csharp
from t in _db.GetAll<table_name>()
select new
{
    pos = t.column_name.RegexpInstr(pattern, position, occurrence, returnOption, matchParameter)
}
```

#### SQL tương đương
```sql
REGEXP_INSTR(column_name, pattern [, position [, occurrence [, return_option [, match_parameter ]]]])
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` nguồn.|
|*pattern*|Bắt buộc. Biểu thức chính quy dùng để tìm vị trí khớp.|
|*position*|Không bắt buộc. Vị trí bắt đầu tìm kiếm. Mặc định Oracle là `1`.|
|*occurrence*|Không bắt buộc. Lần xuất hiện thứ mấy cần lấy.|
|*returnOption*|Không bắt buộc. `0` trả về vị trí bắt đầu khớp, `1` trả về vị trí ngay sau phần khớp.|
|*matchParameter*|Không bắt buộc. Tuỳ chọn Oracle regex như `i`, `c`, `n`, `m`, `x`.|

#### Ví dụ
```csharp
from h in _db.GetAll<HosoDb>()
select new
{
    h.Id,
    Pos = h.Ten.RegexpInstr("[0-9]+")
}
```

### 🔸 Hàm RegexpCount
------------------------
#### Định nghĩa và cách sử dụng
Dùng hàm `RegexpCount()` trong LINQ để sinh ra hàm Oracle `REGEXP_COUNT(...)`.

Hàm này trả về số lần chuỗi nguồn khớp với biểu thức chính quy. Phù hợp khi:
- đếm số ký tự số trong chuỗi
- đếm số token/phần tử phân tách bởi regex
- làm điều kiện lọc hoặc thống kê

#### Cú pháp
##### ➣ Trường hợp 1: 2 tham số
```csharp
from t in _db.GetAll<table_name>()
select new
{
    total = t.column_name.RegexpCount(pattern)
}
```

##### ➣ Trường hợp 2: có `position`, `matchParameter`
```csharp
from t in _db.GetAll<table_name>()
select new
{
    total = t.column_name.RegexpCount(pattern, position, matchParameter)
}
```

#### SQL tương đương
```sql
REGEXP_COUNT(column_name, pattern [, position [, match_parameter]])
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` nguồn.|
|*pattern*|Bắt buộc. Biểu thức chính quy cần đếm số lần khớp.|
|*position*|Không bắt buộc. Vị trí bắt đầu đếm.|
|*matchParameter*|Không bắt buộc. Tuỳ chọn Oracle regex như `i`, `c`, `n`, `m`, `x`.|

#### Ví dụ
```csharp
from h in _db.GetAll<HosoDb>()
select new
{
    h.Id,
    DigitCount = h.Ten.RegexpCount("[0-9]")
}
```

### 🔸 Hàm ReplaceOracle
------------------------
#### Định nghĩa và cách sử dụng
Dùng hàm `ReplaceOracle()` trong LINQ để sinh ra hàm Oracle `REPLACE(source, search, replacement)`.

Khác với `RegexpReplace`, hàm này thay thế theo chuỗi thường, không dùng biểu thức chính quy. Dùng khi:
- thay nhanh dấu `-`, `/`, `.`
- chuẩn hoá mã bằng thay thế đơn giản
- tối ưu hơn regex trong các trường hợp không cần biểu thức chính quy

#### Cú pháp
```csharp
from t in _db.GetAll<table_name>()
select new
{
    value = t.column_name.ReplaceOracle(search, replacement)
}
```

#### SQL tương đương
```sql
REPLACE(column_name, search, replacement)
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` nguồn.|
|*search*|Bắt buộc. Chuỗi cần thay thế.|
|*replacement*|Bắt buộc. Chuỗi thay thế.|

#### Ví dụ
```csharp
from h in _db.GetAll<HosoDb>()
select new
{
    h.Id,
    SoHoSoNorm = h.SoHoSo.ReplaceOracle("-", "")
}
```

### 🔸 Hàm Instr
------------------------
#### Định nghĩa và cách sử dụng
Dùng hàm `Instr()` trong LINQ để sinh ra hàm Oracle `INSTR(...)`.

Hàm này trả về vị trí của chuỗi con trong chuỗi nguồn. Dùng khi:
- kiểm tra một chuỗi có chứa từ khoá hay không
- xác định vị trí phân cách
- thay cho `Contains` trong các tình huống cần SQL Oracle tường minh

#### Cú pháp
##### ➣ Trường hợp 1: 2 tham số
```csharp
from t in _db.GetAll<table_name>()
select new
{
    pos = t.column_name.Instr(subString)
}
```

##### ➣ Trường hợp 2: đầy đủ tham số
```csharp
from t in _db.GetAll<table_name>()
select new
{
    pos = t.column_name.Instr(subString, position, occurrence)
}
```

#### SQL tương đương
```sql
INSTR(column_name, subString [, position [, occurrence]])
```

##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` nguồn.|
|*subString*|Bắt buộc. Chuỗi con cần tìm.|
|*position*|Không bắt buộc. Vị trí bắt đầu tìm kiếm.|
|*occurrence*|Không bắt buộc. Lần xuất hiện thứ mấy cần trả về.|

#### Ví dụ
```csharp
from h in _db.GetAll<HosoDb>()
select new
{
    h.Id,
    Pos = h.Ten.Instr("BHXH")
}
```

#### Ghi chú
- Nếu chỉ cần thay thế chuỗi thường, nên dùng `ReplaceOracle()` thay vì `RegexpReplace()`.
- Nếu cần lọc theo mẫu regex, nên dùng `RegexpLike()` trong `where`.
- Nếu cần chuẩn hoá chuỗi để tìm kiếm, `RegexpReplace()` và `ReplaceOracle()` là hai hàm nên dùng nhiều nhất.
- `RegexpInstr()` và `Instr()` phù hợp khi cần lấy vị trí xuất hiện để phục vụ tiếp các phép xử lý khác.

### 🔸 Hàm RegexpSubstr
------------------------
#### Định nghĩa và cách sử dụng
Sử dụng hàm `REGEXP_SUBSTR` trong Oracle để chuyển 1 chuỗi thành 1 danh sách.

#### SQL
##### Định nghĩa hàm **REGEXP_SUBSTR** trong Oracle

Hàm REGEXP_SUBSTR trong Oracle/PLSQL là phần mở rộng của hàm SUBSTR.
Hàm này, được giới thiệu từ phiên bản Oracle 10g, cho phép bạn trích xuất một chuỗi con từ chuỗi gốc bằng cách sử dụng biểu thức chính quy (regular expression) để so khớp mẫu.

##### Cú pháp SQL
```sql
REGEXP_SUBSTR( string, pattern [, start_position [, nth_appearance [, match_parameter [, sub_expression ] ] ] ] )
```
Tuy nhiên ở đây chúng ta sẽ không sử dụng đơn thuần hàm `REGEXP_SUBSTR` mà sẽ kết hợp để thành 1 hàm lấy ra 1 danh sách đối tượng (như 1 table ảo trong oracle) bằng cấu trúc:
```sql
...
(SELECT REGEXP_SUBSTR ( string, pattern, 1, LEVEL) FROM DUAL CONNECT BY string IS NOT NULL)
...
```
###### Parameters or Arguments
* **string**
> Chuỗi cần tìm kiếm. Có thể là các kiểu dữ liệu: CHAR, VARCHAR2, NCHAR, NVARCHAR2, CLOB hoặc NCLOB.

* **pattern**
> Thông tin biểu thức chính quy dùng để so khớp. Có thể là sự kết hợp của các ký tự sau:


| **Giá trị** | **Mô tả**                                                                                                        |                                                    |
| ----------- | ---------------------------------------------------------------------------------------------------------------- | -------------------------------------------------- |
| `^`         | Khớp với **đầu chuỗi**. Nếu dùng với `match_parameter = 'm'`, sẽ khớp với **đầu dòng** bất kỳ trong biểu thức.   |                                                    |
| `$`         | Khớp với **cuối chuỗi**. Nếu dùng với `match_parameter = 'm'`, sẽ khớp với **cuối dòng** bất kỳ trong biểu thức. |                                                    |
| `*`         | Khớp với **không hoặc nhiều lần lặp**.                                                                           |                                                    |
| `+`         | Khớp với **ít nhất một lần lặp**.                                                                                |                                                    |
| `?`         | Khớp với **không hoặc một lần lặp**.                                                                             |                                                    |
| `.`         | Khớp với **bất kỳ ký tự nào** ngoại trừ `NULL`.                                                                  |                                                    |
| \`          | \`                                                                                                               | Dùng như **“OR”**, để chỉ định **nhiều lựa chọn**. |
| `[ ]`       | Chỉ định **danh sách ký tự cần khớp**, chỉ cần **một ký tự** trong danh sách là phù hợp.                         |                                                    |
| `[^ ]`      | Chỉ định **danh sách không khớp**, tức là **tránh những ký tự trong danh sách**.                                 |                                                    |
| `( )`       | Nhóm biểu thức thành **biểu thức con**.                                                                          |                                                    |
| `{m}`       | Khớp **chính xác m lần**.                                                                                        |                                                    |
| `{m,}`      | Khớp **ít nhất m lần**.                                                                                          |                                                    |
| `{m,n}`     | Khớp **ít nhất m lần, nhiều nhất n lần**.                                                                        |                                                    |
| `\n`        | `n` là số từ 1 đến 9. Khớp với **biểu thức con thứ n** được tìm thấy trước `\n`.                                 |                                                    |
| `[..]`      | Khớp với một **yếu tố sắp xếp** (collation element) có thể là nhiều ký tự.                                       |                                                    |
| `[::]`      | Khớp với **nhóm ký tự** (character classes).                                                                     |                                                    |
| `[==]`      | Khớp với **nhóm tương đương** (equivalence classes).                                                             |                                                    |
| `\d`        | Khớp với **ký tự số**.                                                                                           |                                                    |
| `\D`        | Khớp với **ký tự không phải số**.                                                                                |                                                    |
| `\w`        | Khớp với **ký tự từ** (chữ, số, gạch dưới).                                                                      |                                                    |
| `\W`        | Khớp với **ký tự không phải từ**.                                                                                |                                                    |
| `\s`        | Khớp với **khoảng trắng** (space, tab, xuống dòng, v.v.).                                                        |                                                    |
| `\S`        | Khớp với **ký tự không phải khoảng trắng**.                                                                      |                                                    |
| `\A`        | Khớp với **đầu chuỗi**, hoặc **trước ký tự xuống dòng** ở cuối chuỗi.                                            |                                                    |
| `\Z`        | Khớp với **cuối chuỗi**.                                                                                         |                                                    |
|             |                                                                                                                  |                                                    |


#### Cú pháp
```c#
from t in _db.GetAll<table_name>() 
where source.RegexpSubstr(pattern).Any(x => t.column_name == x)
select selector  
```
##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*source*|Chuỗi string được phân cách bằng: `','`, `';'`, `'/'`, ...|
|*pattern*|Như phần mô tả tại mục **Parameters or Arguments** của **Cú pháp SQL**|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` cần so sánh để tìm kiếm trong tập hợp lấy được từ **`REGEXP_SUBSTR`**|
|*selector*|Bắt buộc. Giá trị cần lấy ra|

### 🔸 Hàm RegexpSubstrToNumber
------------------------
#### Định nghĩa và cách sử dụng
Tương tự như với [**`RegexpSubstr`**](#-h%C3%A0m-regexpsubstr) nhưng tập hợp lấy ra là kiểu **`NUMBER`**.
#### SQL
##### Cú pháp SQL
```sql
...
(SELECT TO_NUMBER(REGEXP_SUBSTR ( string, pattern, 1, LEVEL)) FROM DUAL CONNECT BY REGEXP_SUBSTR (string, pattern, 1, LEVEL) IS NOT NULL)
...
```
###### Parameters or Arguments
Tương tự như [**`RegexpSubstr`**](#parameters-or-arguments).
#### Cú pháp
```c#
from t in _db.GetAll<table_name>() 
where source.RegexpSubstrToNumber(pattern).Any(x => t.column_name == x)
select selector  
```
##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*source*|Chuỗi string của kiểu số, được phân cách bằng: `','`, `';'`, `'/'`, ...|
|*pattern*|Như phần mô tả **pattern** tại mục [**Parameters or Arguments**](#parameters-or-arguments)|
|*column_name*|Bắt buộc. Tên thuộc tính được map từ `COLUMN` cần so sánh để tìm kiếm trong tập hợp lấy được từ **`REGEXP_SUBSTR`** *(Bắt buộc phải là kiểu* ***`NUMBER`****)*|
|*selector*|Bắt buộc. Giá trị cần lấy ra|


### 🔸 Hàm WithAs và EndWithAsOf
------------------------
#### Định nghĩa và cách sử dụng
Cho phép gán tên cho khối truy vấn con (**Subquery**). Sau đó bạn có thể tham chiếu khối truy vấn con đó ở nhiều vị trí trong câu truy vấn bằng cách chỉ định tên truy vấn. Oracle tối ưu hóa truy vấn bằng cách coi tên truy vấn là một dạng xem nội tuyến hoặc là một bảng tạm (**temporary table**).
#### SQL
##### Cú pháp SQL
```sql
WITH cte_name [(col_name [, col_name] ...)] AS (subquery)
    [, cte_name [(col_name [, col_name] ...)] AS (subquery)] ...
```
|Parameter|Description|
|---------|-----------|
|*cte_name*| tên của CTE được sử dụng làm tham chiếu đến bảng trong câu lệnh chưa mệnh đề With.|
|*subquery*|  được gọi là truy vấn con của CTE và là phần tạo ra tập kết quả của CTE. Subquery phải nằm trong dấu ngoặc đơn.|
##### Ví dụ
```sql
SQL> WITH DEPT_COUNT AS
     (SELECT DEPT_ID, COUNT(*) DEPT_COUNT
      FROM EMPLOYEE
      GROUP BY DEPT_ID)
     SELECT E1.EMP_NAME, E2.DEPT_COUNT
     FROM EMPLOYEE E1, DEPT_COUNT E2
     WHERE E1.DEPT_ID = E2.DEPT_ID;

EMP_NAME                                           DEPT_COUNT
-------------------------------------------------- ----------
ADAMS                                                       7
TURNER                                                      7
CLARK                                                       7
MARTIN                                                      7
WARD                                                        7
ALLEN                                                       7
BLAKE                                                       7
ADAMS                                                       5
SCOTT                                                       5
SMITH                                                       5
FORD                                                        5
JONES                                                       5
MILLER                                                      2
KING                                                        2

14 rows selected.
```
#### Cú pháp
```csharp
...
(from t in _db.GetAll<table_name>()
join cte in sub_query.WithAs("cte") on t.column equals cte.column
where condition
select new {
    t.column_name(s)
}).EndWithAsOf("cte")
...
```
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*subquery*|  Được gọi là truy vấn con của CTE và là phần tạo ra tập kết quả của CTE. Subquery phải là 1 IQueryable.|

#### Ví dụ
Dưới đây là 1 ví dụ cho việc sử dụng hiệu quả `WithAs`:

```csharp
var qrMangLuoi = from ml in _db.GetAll<MangLuoiDb>()
                 where (ml.Type == input.LoaiGiaoDich).IfGenerateQuery(input.LoaiGiaoDich != 0)
                 && (ml.ConnectBy(ml.Chaid, ancestorId, ml => ml.Id == ml.Chaid)).IfGenerateQuery(!input.IsDaiLyOnly)
                 && (ml.Id == ancestorId).IfGenerateQuery(input.IsDaiLyOnly)
                 select new
                 {
                     ml.Id,
                     ml.TrangThai,
                     ml.Chaid,
                     ml.Ma,
                     ancestorId = (input.IsDaiLyOnly).IfSelectQuery(ml.Id, ml.Id.ConnectByRoot()),
                     ancestorMa = (input.IsDaiLyOnly).IfSelectQuery(ml.Ma, ml.Ma.ConnectByRoot()),
                     ancestorTen = (input.IsDaiLyOnly).IfSelectQuery(ml.Ten, ml.Ten.ConnectByRoot()),
                     maTinh = (input.IsDaiLyOnly).IfSelectQuery(ml.Matinh, ml.Matinh.ConnectByRoot()),
                     ancestorTrangThai = (input.IsDaiLyOnly).IfSelectQuery(ml.TrangThai, ml.TrangThai.ConnectByRoot())
                 };
 var filtered = await _db.ToListAsync(from sub in
                               from t in
                                   (from bl in _db.GetAll<BienLaiDb>()
                                    join tran in _db.GetAll<TransactionDb>() on bl.Id equals tran.BienLaiId
                                    join u in _db.GetAll<UsersDb>() on bl.UserId equals u.Id
                                    join m in qrMangLuoi.WithAs("MNG") on bl.MangLuoiId equals m.Id
                                    where bl.CreateDate >= input.From.Date
                                       && bl.CreateDate < input.To.Date
                                       && (bl.Madonvi == input.MaDonVi).IfGenerateQuery(!string.IsNullOrWhiteSpace(input.MaDonVi))
                                       && m.maTinh == bl.MatinhCreate
                                       && tran.CreateDate >= input.From.Date
                                       && tran.CreateDate < input.To.Date
                                       && tran.MatinhCreate == m.maTinh
                                       && (m.TrangThai == BooleanShort.False).IfGenerateQuery(input.TrangThaiDaiLy == BooleanShort.False)
                                       && (m.ancestorTrangThai == BooleanShort.True && m.TrangThai == BooleanShort.True).IfGenerateQuery(input.TrangThaiDaiLy == BooleanShort.True)
                                       && ((tran.IsApp == 1 || tran.IsWeb == 1) && tran.IsHinhThuc.IsNull()).IfGenerateQuery(input.HinhThuc == BaoCaoKeKhaiHinhThuc.WebApp)
                                       && (tran.IsHinhThuc == 1 && (tran.IsApp.IsNull() && tran.IsWeb.IsNull())).IfGenerateQuery(input.HinhThuc == BaoCaoKeKhaiHinhThuc.CongThu) 
                                    select new
                                    {
                                        maCoQuanBHXH = bl.Macoquanbhxh,
                                        maNhanVienThu = u.Manhanvienthu,
                                        ngayBienLai = bl.CreateDate,
                                        soBienLai = bl.So,
                                        maSoBHXH = tran.Masobhxh,
                                        soTienBHXH = bl.SotienBhxh,
                                        soTienBHYT = bl.SotienBhyt,
                                        bl.Type,
                                        bl.Tinhchat,
                                        m.ancestorTen,
                                        m.ancestorMa,
                                        m.ancestorId,
                                        MaDonVi = tran.Madonvi,
                                        bl.GhiChu,
                                        bl.CreateDate
                                    }).Union(from ibl in _db.GetAll<IvanBienlaiDb>()
                                             join itk in _db.GetAll<IvanTokhaiDb>() on ibl.Id equals itk.BienLaiId
                                             join u in _db.GetAll<UsersDb>() on ibl.UserId equals u.Id
                                             join m in qrMangLuoi.WithAs("MNG") on new { MangLuoiId = ibl.MangLuoiId, maTinh = ibl.MatinhCreate } equals new { MangLuoiId = m.Id, maTinh = m.maTinh }
                                             where ibl.CreateDate >= blFromDate
                                                && ibl.CreateDate < blToDate
                                                && (ibl.Madonvi == input.MaDonVi).IfGenerateQuery(!string.IsNullOrWhiteSpace(input.MaDonVi))
                                                && (m.TrangThai == BooleanShort.False).IfGenerateQuery(input.TrangThaiDaiLy == BooleanShort.False)
                                                && (m.ancestorTrangThai == BooleanShort.True && m.TrangThai == BooleanShort.True).IfGenerateQuery(input.TrangThaiDaiLy == BooleanShort.True)
                                             select new
                                             {
                                                 maCoQuanBHXH = ibl.Macoquanbhxh,
                                                 maNhanVienThu = u.Manhanvienthu,
                                                 ngayBienLai = ibl.CreateDate,
                                                 soBienLai = ibl.So,
                                                 maSoBHXH = itk.Masobhxh,
                                                 soTienBHXH = ibl.SotienBhxh,
                                                 soTienBHYT = ibl.SotienBhyt,
                                                 ibl.Type,
                                                 ibl.Tinhchat,
                                                 m.ancestorTen,
                                                 m.ancestorMa,
                                                 m.ancestorId,
                                                 MaDonVi = ibl.Madonvi,
                                                 ibl.GhiChu,
                                                 ibl.CreateDate
                                             }).EndWithAsOf("MNG")
                               select new
                               {
                                   t.maCoQuanBHXH,
                                   t.maNhanVienThu,
                                   t.ngayBienLai,
                                   t.soBienLai,
                                   t.maSoBHXH,
                                   t.soTienBHXH,
                                   t.soTienBHYT,
                                   t.Type,
                                   t.Tinhchat,
                                   t.MaDonVi,
                                   t.GhiChu,
                                   TenBuuCuc = t.ancestorTen,
                                   MaBuuCuc = t.ancestorMa,
                                   row_num = t.DenseRank(() => new { t.ancestorMa, t.ancestorId }),
                                   TongSoBuuCuc = 1.Count(() => new { t.ancestorMa, t.ancestorId }),
                                   TongSoBienLai = 1.Count(() => 1),
                                   t.CreateDate
                               }
                           select new
                           {
                               sub.maCoQuanBHXH,
                               sub.maNhanVienThu,
                               sub.ngayBienLai,
                               sub.soBienLai,
                               sub.maSoBHXH,
                               sub.soTienBHXH,
                               sub.soTienBHYT,
                               sub.Type,
                               sub.Tinhchat,
                               sub.TenBuuCuc,
                               sub.MaBuuCuc,
                               sub.MaDonVi,
                               sub.GhiChu,
                               sub.row_num,
                               totalrow = sub.row_num.Max(() => 1),
                               sub.TongSoBuuCuc,
                               sub.TongSoBienLai,
                               Stt = sub.RowNumber(() => sub.TenBuuCuc, () => sub.CreateDate)
                           }, isMapping: false)
```

### 🔸 Hàm HintIndex
------------------------
#### Định nghĩa và cách sử dụng
Hint (gợi ý) trong Oracle là một cách để cung cấp chỉ dẫn cho trình tối ưu hóa truy vấn về cách thức thực hiện một câu lệnh SQL. Hint được thêm vào câu lệnh SQL để chỉ định kế hoạch thực hiện cụ thể cho Oracle Optimizer. Chúng giúp người phát triển hoặc quản trị cơ sở dữ liệu can thiệp vào quá trình tối ưu hóa truy vấn để đạt được hiệu suất mong muốn.

###### Hint INDEX thường được dùng trong các trường hợp sau:
> * Hiệu suất không đạt yêu cầu: Nếu sau khi kiểm tra và đánh giá hiệu suất của truy vấn, bạn thấy rằng trình tối ưu hóa không chọn kế hoạch thực hiện phù hợp, và bạn có một kế hoạch tối ưu hơn, bạn có thể cân nhắc sử dụng hint để áp đặt kế hoạch đó.

> * Chỉ mục không được chọn đúng: Khi bạn muốn đảm bảo rằng một chỉ mục cụ thể được sử dụng hoặc ngăn chặn sử dụng chỉ mục, bạn có thể sử dụng hint INDEX.

#### Cú pháp

```csharp
from table in _db.GetAll<table_name>().HintIndex(index_name, table => table.Id)
where condition
select selector
```
##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*table_name*|Bắt buộc. Tên object được map từ DB.|
|*index_name*|Tên INDEX cần Hint|
|*selector*|Bắt buộc. Giá trị cần lấy ra|

#### Ví dụ
```csharp
from bl in _db.GetAll<BienLaiDb>().HintIndex("BIEN_LAI_IDX_HA03", bl => bl.Id)
where bl.CreateDate >= blFromDate
    && bl.CreateDate < blToDate
select new
{
    bl.MangLuoiId
}
```

---
📌 Các hàm hỗ trợ trong NET
-------------------------------------

### 🔸 Hàm ConvertToXml
----------------------------
#### Định nghĩa và cách sử dụng
Chuyển đổi `object` thành `XmlDocument` (phục vụ cho cá hàm `XMLTable`, [`XMLTableOfNumber`](#-h%C3%A0m-xmltableofnumber), `XMLTableOfString`)
#### Cú pháp
```c#
object.ConvertToXml()  
```
##### Parameter Values
|Parameter|Description|
|---------|-----------|
|*object*|Bắt buộc. Tên object sẽ chuyển thành xml.<br>Mỗi thuộc tính của object sẽ được chuyển thành node trong xml|

#### Ví dụ
```c#
var xmlCqtc = new { coquan = coQuans.Select(x => x.Id).ToList() }.ConvertToXml();

Output:
<root>
  <coquan>3921</coquan>
  <coquan>3953</coquan>
  <coquan>3969</coquan>
  <coquan>3982</coquan>
  <coquan>3993</coquan>
  <coquan>4000</coquan>
  <coquan>4011</coquan>
  <coquan>4020</coquan>
  <coquan>4029</coquan>
</root>
```

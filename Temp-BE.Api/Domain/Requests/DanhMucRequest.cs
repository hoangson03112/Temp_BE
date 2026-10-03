namespace Temp_BE.Domain.Requests
{
    public class CreateDanhMucRequest
    {
        public string TenDm { get; set; } = default!;
        public string? MoTa { get; set; }
        public int? TrangThai { get; set; }
    }
    public class UpdateDanhMucRequest
    {
        public string TenDm { get; set; } = default!;
        public string? MoTa { get; set; }
        public int TrangThai { get; set; }
    }
}

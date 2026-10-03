namespace Temp_BE.Domain.DTOs
{
    public class DanhMucDto
    {
        public string MaDm { get; set; } = default!;
        public string TenDm { get; set; } = default!;
        public string? MoTa { get; set; }
        public int TrangThai { get; set; }
    }


}
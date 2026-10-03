namespace Temp_BE.Domain.DTOs
{
    public class SanPhamDto
    {
        public string MaSp { get; set; } = string.Empty;
        public string TenSp { get; set; } = string.Empty;
        public decimal GiaBan { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? TrangThai { get; set; }
    }
}
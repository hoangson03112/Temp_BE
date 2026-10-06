namespace Temp_BE.Domain.Requests
{
    public class CreateSanPhamRequest
    {
        public string TenSp { get; set; } = string.Empty;
        public decimal GiaBan { get; set; }
        public decimal? SoLuong { get; set; } = 0;
        public decimal TrangThai { get; set; } = 1;
    }
    public class UpdateSanPhamRequest
    {
        public string TenSp { get; set; } = string.Empty;
        public decimal GiaBan { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? TrangThai { get; set; }
    }
    public class UpdateTrangThaiSanPhamRequest
    {
        public decimal TrangThai { get; set; }
    }
}

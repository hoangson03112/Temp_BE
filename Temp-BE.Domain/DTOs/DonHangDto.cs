namespace Temp_BE.Domain.DTOs
{
    public class CreateDonHangDto
    {
        public string TenNguoiNhan { get; set; } = default!;
        public string SoDt { get; set; } = default!;
        public string DiaChi { get; set; } = default!;
        public string? GhiChu { get; set; }
        public List<CreateChiTietDonHangDto> ChiTiet { get; set; } = new();
    }
    public class UpdateOrderStatusDto
    {
        public int TrangThai { get; set; }

    }
    public class DonHangDto
    {
        public string MaDh { get; set; }
        public long UserId { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SoDt { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public List<ChiTietDonHangDto> DanhSachMon { get; set; } = new();

    }

}

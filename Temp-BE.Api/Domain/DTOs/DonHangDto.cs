namespace Temp_BE.Domain.DTOs
{


    public class DonHangDto
    {
        public string MaDh { get; set; } = default!;
        public long UserId { get; set; }
        public string TenNguoiNhan { get; set; } = default!;
        public string SoDt { get; set; } = default!;
        public string DiaChi { get; set; } = default!;
        public decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public List<ChiTietDonHangDto> DanhSachMon { get; set; } = new();
    }

}

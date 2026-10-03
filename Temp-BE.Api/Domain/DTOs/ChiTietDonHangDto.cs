namespace Temp_BE.Domain.DTOs
{


    public class ChiTietDonHangDto
    {
        public long Id { get; set; } = default;
        public string MaSp { get; set; } = default!;
        public string? TenSp { get; set; }
        public decimal SoLuong { get; set; }
        public string MaDh { get; set; } = default!;
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}

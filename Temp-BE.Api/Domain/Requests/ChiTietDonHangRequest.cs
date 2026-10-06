namespace Temp_BE.Domain.Requests
{
    public class CreateChiTietDonHangRequest
    {
        public string MaSp { get; set; } = default!;
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string? TenSp { get; set; }
    }
}

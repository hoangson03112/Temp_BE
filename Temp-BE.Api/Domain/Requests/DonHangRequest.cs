namespace Temp_BE.Domain.Requests
{
    public class CreateDonHangRequest
    {
        public string TenNguoiNhan { get; set; } = default!;
        public string SoDt { get; set; } = default!;
        public string DiaChi { get; set; } = default!;
        public string? GhiChu { get; set; }
        public List<CreateChiTietDonHangRequest> ChiTiet { get; set; } = new();
    }
    public class UpdateOrderStatusRequest
    {
        public int TrangThai { get; set; }

    }
}

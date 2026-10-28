namespace Temp_BE.Domain.DTOs
{
    public class BaoCaoSanPhamData
    {
        public string DonViCapTren { get; set; } = "TỔNG CÔNG TY...";
        public string DonViBaoCao { get; set; } = "CÔNG TY ABC";
        public string NgayBaoCao { get; set; } = $"Ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}";
        public string NguoiLap { get; set; } = "Người lập";
        public string KeToanTruong { get; set; } = "Kế toán trưởng";
        public string ThuTruongDonVi { get; set; } = "Thủ trưởng đơn vị";
        public List<SanPhamDto> Items { get; set; } = new();
    }
}
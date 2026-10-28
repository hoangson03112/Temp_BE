using Temp_BE.Domain.Enums;

namespace Temp_BE.Domain.Requests
{
    public class SanPhamReportRequest : SanPhamFilterRequest
    {
        public ExportFormat Format { get; set; } = ExportFormat.Pdf;
        public string? DonViCapTren { get; set; }
        public string? DonViBaoCao { get; set; }
        public int? Quy { get; set; }
        public int? Nam { get; set; }
        public string? NgayBaoCao { get; set; }
        public string? NguoiLap { get; set; }
        public string? KeToanTruong { get; set; }
        public string? ThuTruongDonVi { get; set; }
    }
}

using Temp_BE.Domain.Enums;

namespace Temp_BE.Domain.Requests
{
    public class ReportRequest
    {
        public ReportType ReportType { get; set; } = ReportType.SanPham;
        public ExportFormat Format { get; set; } = ExportFormat.Pdf;

        public int? Month { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Keyword { get; set; }

        public string? CompanyCode { get; set; }
        public string? DepartmentCode { get; set; }
        public string? AccountCode { get; set; }

        public Dictionary<string, string> Extra { get; set; } = new();
    }
}
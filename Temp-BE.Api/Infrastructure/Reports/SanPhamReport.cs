using DevExpress.XtraReports.UI;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Infrastructure.Reports
{
    public partial class SanPhamReport : XtraReport
    {
        public SanPhamReport()
        {
            InitializeComponent();
        }

        public SanPhamReport(IEnumerable<SanPhamDto>? data) : this()
        {
            ApplyData(data);
        }

        public void ApplyData(IEnumerable<SanPhamDto>? data)
        {
            this.DataSource = data?.ToList() ?? new List<SanPhamDto>();
        }

        public void SetReportParameters(
            string? donViCapTren = null,
            string? donViBaoCao = null,
            int? quy = null,
            int? nam = null,
            string? ngayBaoCao = null,
            string? nguoiLap = null,
            string? keToanTruong = null,
            string? thuTruongDonVi = null)
        {
            var now = DateTime.Now; 
            var currentQuarter = (now.Month - 1) / 3 + 1;

            SetParameterValue("pDonViCapTren", !string.IsNullOrWhiteSpace(donViCapTren) ? donViCapTren : "TỔNG CÔNG TY THƯƠNG MẠI");
            SetParameterValue("pDonViBaoCao", !string.IsNullOrWhiteSpace(donViBaoCao) ? donViBaoCao : "CHI NHÁNH MIỀN BẮC");
            SetParameterValue("pQuy", quy ?? currentQuarter);
            SetParameterValue("pNam", nam ?? now.Year);
            SetParameterValue("pNgayBaoCao", !string.IsNullOrWhiteSpace(ngayBaoCao) ? ngayBaoCao : $"Ngày {now:dd} tháng {now:MM} năm {now:yyyy}");
            SetParameterValue("pNguoiLap", !string.IsNullOrWhiteSpace(nguoiLap) ? nguoiLap : "Người lập biểu");
            SetParameterValue("pKeToanTruong", !string.IsNullOrWhiteSpace(keToanTruong) ? keToanTruong : "Kế toán trưởng");
            SetParameterValue("pThuTruongDonVi", !string.IsNullOrWhiteSpace(thuTruongDonVi) ? thuTruongDonVi : "Thủ trưởng đơn vị");

            this.RequestParameters = false;
        }

        private void SetParameterValue(string paramName, object value)
        {
            if (Parameters[paramName] != null)
            {
                Parameters[paramName].Value = value;
            }
        }
    }
}
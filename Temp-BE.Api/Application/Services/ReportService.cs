using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.Requests;
using Temp_BE.Domain.Responses;
using Temp_BE.Infrastructure.Renderer;
using Temp_BE.Infrastructure.Reports;

namespace Temp_BE.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly ISanPhamRepository _sanPhamRepo;
        private readonly IDevExpressReportRenderer _reportRenderer;

        public ReportService(
            ISanPhamRepository sanPhamRepo,
            IDevExpressReportRenderer reportRenderer)
        {
            _sanPhamRepo = sanPhamRepo;
            _reportRenderer = reportRenderer;
        }

        public async Task<ReportResult> ExportSanPhamReportAsync(SanPhamReportRequest request, CancellationToken ct = default)
        {
            var items = await _sanPhamRepo.GetAllForReportAsync(request, ct);

            using var report = new SanPhamReport(items);
            report.SetReportParameters(
                donViCapTren: request.DonViCapTren,
                donViBaoCao: request.DonViBaoCao,
                quy: request.Quy,
                nam: request.Nam,
                ngayBaoCao: request.NgayBaoCao,
                nguoiLap: request.NguoiLap,
                keToanTruong: request.KeToanTruong,
                thuTruongDonVi: request.ThuTruongDonVi
            );

            return await _reportRenderer.RenderAsync(report, "DanhSachSanPham", request.Format, ct);
        }


        //public async Task<ProductReportDto> GetProductReportDataAsync(string? keyword = null, CancellationToken ct = default)
        //{
        //    var filterReq = new SanPhamFilterRequest { Keyword = keyword };
        //    var products = await _sanPhamRepo.GetAllForReportAsync(filterReq, ct);

        //    var now = DateTime.Now;
        //    var currentQuarter = (now.Month - 1) / 3 + 1;

        //    return new ProductReportDto
        //    {
        //        Title = "BÁO CÁO DANH SÁCH SẢN PHẨM",
        //        CompanyName = "TỔNG CÔNG TY THƯƠNG MẠI",
        //        DepartmentName = "CHI NHÁNH MIỀN BẮC",
        //        Quarter = currentQuarter,
        //        Year = now.Year,
        //        ReportDate = $"Ngày {now:dd} tháng {now:MM} năm {now:yyyy}",
        //        Creator = "Người lập biểu",
        //        ChiefAccountant = "Kế toán trưởng",
        //        Director = "Thủ trưởng đơn vị",
        //        Products = products.Select((p, idx) => new ProductItemDto
        //        {
        //            Stt = idx + 1,
        //            ProductCode = p.MaSp,
        //            ProductName = p.TenSp,
        //            Quantity = p.SoLuong ?? 0,
        //            UnitPrice = p.GiaBan,
        //            Unit = "Cái",
        //            Note = p.TrangThai_Text,
        //            IsBold = p.IsBold
        //        }).ToList()
        //    };
        //}
    }
}
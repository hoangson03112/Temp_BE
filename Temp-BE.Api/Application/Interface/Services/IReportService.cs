using Temp_BE.Domain.Requests;
using Temp_BE.Domain.Responses;

namespace Temp_BE.Application.Interface.Services
{
    public interface IReportService
    {
        //Task<ReportResult> ExportReportAsync(ReportRequest request, CancellationToken ct = default);
        Task<ReportResult> ExportSanPhamReportAsync(SanPhamReportRequest request, CancellationToken ct = default);
    }
}

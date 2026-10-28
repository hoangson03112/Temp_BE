using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Temp_BE.Domain.Responses;
using AppExportFormat = Temp_BE.Domain.Enums.ExportFormat;

namespace Temp_BE.Infrastructure.Renderer
{
    public interface IDevExpressReportRenderer
    {
        Task<ReportResult> RenderAsync(XtraReport report, string baseFileName, AppExportFormat format, CancellationToken ct = default);
    }

    public class DevExpressReportRenderer : IDevExpressReportRenderer
    {
        public async Task<ReportResult> RenderAsync(XtraReport report, string baseFileName, AppExportFormat format, CancellationToken ct = default)
        {
            using var ms = new MemoryStream();
            string extension;
            string contentType;

            switch (format)
            {
                case AppExportFormat.Excel:
                    var xlsxOptions = new XlsxExportOptions
                    {
                        ExportMode = XlsxExportMode.SingleFile,
                        SheetName = "DanhSach"
                    };
                    await report.ExportToXlsxAsync(ms, xlsxOptions, ct);
                    extension = "xlsx";
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case AppExportFormat.Csv:
                    var csvOptions = new CsvExportOptions
                    {
                        Encoding = System.Text.Encoding.UTF8
                    };
                    await report.ExportToCsvAsync(ms, csvOptions, ct);
                    extension = "csv";
                    contentType = "text/csv; charset=utf-8";
                    break;
                case AppExportFormat.Pdf:
                default:
                    var pdfOptions = new PdfExportOptions
                    {
                        Compressed = true
                    };
                    await report.ExportToPdfAsync(ms, pdfOptions, ct);
                    extension = "pdf";
                    contentType = "application/pdf";
                    break;
            }

            var bytes = ms.ToArray();
            var fileName = $"{baseFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}";

            return new ReportResult
            {
                FileName = fileName,
                ContentType = contentType,
                Bytes = bytes,
                TotalPages = report.Pages.Count
            };
        }
    }
}

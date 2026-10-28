using Microsoft.AspNetCore.Mvc;
using Temp_BE.Api.Controllers;
using Temp_BE.Api.Domain.DTOs;
using Temp_BE.Api.Infrastructure.Persistence;
using Temp_BE.Api.Infrastructure.Reports;
[Route("api/bao-cao")]
[ApiController]
public class BaoCaoController : BaseApiController
{
    [HttpGet("export-mau12-cbh")]
    public async Task<IActionResult> ExportMau12Cbh()
    {

        using var report = new Mau12Report();
        report.DataSource = ReportMockData.GetMau12MockData();
        report.lblBhxh.Text = "BẢO HIỂM XÃ HỘI TỈNH / THÀNH PHỐ HÀ NỘI";
        report.lblCoSo.Text = "BHXH cơ sở số: 01 - Ba Đình Xã, phường, tổ chi trả: Phường Điện Biên";
        report.lblThangNam.Text = $"Tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
        report.lblHinhThuc.Text = "Hình thức chi trả: Tiền mặt";
        report.lblNguon.Text = "Nguồn kinh phí: Nguồn Quỹ BHXH";
        report.lblNgayThangNam.Text = $"Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
        report.lblNguoiLapBieu.Text = "Đỗ Văn Minh";
        report.lblKeToanTruong.Text = "Đỗ Văn Minh";
        report.lblThuTruong.Text = "Đỗ Văn Minh";

        using (MemoryStream ms = new MemoryStream())
        {
            await report.ExportToPdfAsync(ms);
            ms.Position = 0;
            return File(ms.ToArray(), "application/pdf", "Mau12_CBH.pdf");
        }
    }
    [HttpPut("custom/mau-12-cbh")]
    public async Task<IActionResult> DesignerMau12([FromBody] ReportConfigDto config)
    {
        using var report = new Mau12Report();
        report.DataSource = ReportMockData.GetMau12MockData();
        report.ApplyCustomConfig(config);


        using (MemoryStream ms = new MemoryStream())
        {
            await report.ExportToPdfAsync(ms);
            ms.Position = 0;
            return File(ms.ToArray(), "application/pdf", "Mau12_CBH.pdf");
        }
    }
}
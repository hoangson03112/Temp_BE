using DevExpress.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Temp_BE.Api.Domain.DTOs;

namespace Temp_BE.Api.Infrastructure.Reports
{
    public partial class Mau12Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Mau12Report()
        {
            InitializeComponent();
        }
        public void ApplyCustomConfig(ReportConfigDto? config)
        {

            if (config == null) return;
            if (config.SetUpTrang != null)
            {
                int MmToUnits(int mm) => (int)Math.Round(mm * 3.937f);

                int left = config.SetUpTrang.CanLeLeft > 0 ? MmToUnits(config.SetUpTrang.CanLeLeft) : (int)this.Margins.Left;
                int right = config.SetUpTrang.CanLeRight > 0 ? MmToUnits(config.SetUpTrang.CanLeRight) : (int)this.Margins.Right;
                int top = config.SetUpTrang.CanLeTop > 0 ? MmToUnits(config.SetUpTrang.CanLeTop) : (int)this.Margins.Top;
                int bottom = config.SetUpTrang.CanLeBottom > 0 ? MmToUnits(config.SetUpTrang.CanLeBottom) : (int)this.Margins.Bottom;

                this.Margins = new DXMargins(left, right, top, bottom);
            }

            if (config.Header != null)
            {
                ApplyTextConfig(lblBhxh, config.Header.TenDonVi);
                ApplyTextConfig(lblCoSo, config.Header.CoSoChiTra);
                ApplyTextConfig(lblHinhThuc, config.Header.HinhThucChiTra);
                ApplyTextConfig(lblNguon, config.Header.NguonKinhPhi);
                if (config.Header.ThangNam != null)
                {
                    var tn = config.Header.ThangNam;

                    lblThangNam.Text = $"Tháng {tn.Thang} năm {tn.Nam}";

                    DXFontStyle style = DXFontStyle.Regular;
                    if (tn.Bold == true) style |= DXFontStyle.Bold;
                    if (tn.Italic == true) style |= DXFontStyle.Italic;

                    string fontName = !string.IsNullOrEmpty(tn.FontFamily) ? tn.FontFamily : lblThangNam.Font.Name;
                    float fontSize = tn.FontSize > 0 ? tn.FontSize : lblThangNam.Font.Size;
                    lblThangNam.Font = new DXFont(fontName, fontSize, style);

                    if (Enum.TryParse<TextAlignment>(tn.Alignment, true, out var align))
                    {
                        lblThangNam.TextAlignment = align;
                    }
                }
            }

            if (config.Grid != null)
            {
                ApplyTableStyle(xrTable1, config.Grid.HeaderRow);
                ApplyTableStyle(xrTable5, config.Grid.DataRow);
                ApplyTableStyle(xrTable11, config.Grid.SummaryRow);

                if (config.Grid.GroupHeader != null)
                {
                    var gh = config.Grid.GroupHeader;
                    DXFontStyle style = gh.Bold ? DXFontStyle.Bold : DXFontStyle.Regular;
                    string fontName = !string.IsNullOrEmpty(gh.FontFamily) ? gh.FontFamily : xrLabel2.Font.Name;
                    float fontSize = gh.FontSize > 0 ? gh.FontSize : xrLabel2.Font.Size;
                    xrLabel2.Font = new DXFont(fontName, fontSize, style);
                }
            }
            if (config.Footer != null)
            {
                if (config.Footer.NgayThang != null)
                {
                    var nt = config.Footer.NgayThang;
                    if (!string.IsNullOrEmpty(nt.FontFamily) && nt.FontSize > 0)
                    {
                        int ngay = DateTime.Now.Day;
                        int thang = DateTime.Now.Month;
                        int nam = DateTime.Now.Year;
                        var style = nt.Italic ? DXFontStyle.Italic : DXFontStyle.Regular;
                        lblNgayThangNam.Font = new DXFont(nt.FontFamily, nt.FontSize, style);
                        lblNgayThangNam.Text = $"Ngày {ngay} Tháng {thang} năm {nam}";

                    }
                    if (Enum.TryParse<TextAlignment>(nt.Alignment, true, out var align))
                        lblNgayThangNam.TextAlignment = align;
                }
                if (config.Footer?.DanhSachNguoiKy != null)
                {
                    xrLabel5.Visible = xrLabel6.Visible = lblNguoiLapBieu.Visible = false;
                    xrLabel11.Visible = xrLabel12.Visible = lblKeToanTruong.Visible = false;
                    xrLabel8.Visible = xrLabel9.Visible = lblThuTruong.Visible = false;

                    var slots = new[]
                    {
            new { Title = xrLabel5, Note = xrLabel6, Name = lblNguoiLapBieu },
            new { Title = xrLabel11, Note = xrLabel12, Name = lblKeToanTruong },
            new { Title = xrLabel8, Note = xrLabel9, Name = lblThuTruong }
        };

                    // 3. Lấy danh sách người ký có HienThi == true (tối đa 3 người theo template)
                    var activeSigners = config.Footer.DanhSachNguoiKy
                        .Where(x => x.HienThi)
                        .Take(3)
                        .ToList();

                    int count = activeSigners.Count;
                    if (count > 0)
                    {
                        float pageWidth = 806f; // Chiều rộng vùng in khổ A4 ngang
                        float colWidth = 220f;  // Độ rộng mỗi khung chữ ký
                        float slotWidth = pageWidth / count;

                        for (int i = 0; i < count; i++)
                        {
                            var signer = activeSigners[i];
                            var slot = slots[i];

                            // Bật hiển thị slot
                            slot.Title.Visible = true;
                            slot.Note.Visible = true;
                            slot.Name.Visible = true;

                            // Gán Tiêu đề chức danh (viết hoa) và Tên người ký từ FE
                            slot.Title.Text = (!string.IsNullOrEmpty(signer.TieuDeNguoiKy) ? signer.TieuDeNguoiKy : signer.ChucDanh ?? "").ToUpper();
                            slot.Name.Text = signer.TenNguoiKy ?? "";

                            // Tính vị trí X căn đều cân đối trang giấy
                            float posX = (i * slotWidth) + (slotWidth - colWidth) / 2f;
                            slot.Title.LocationFloat = new DevExpress.Utils.PointFloat(posX, slot.Title.LocationFloat.Y);
                            slot.Title.SizeF = new System.Drawing.SizeF(colWidth, slot.Title.SizeF.Height);

                            slot.Note.LocationFloat = new DevExpress.Utils.PointFloat(posX, slot.Note.LocationFloat.Y);
                            slot.Note.SizeF = new System.Drawing.SizeF(colWidth, slot.Note.SizeF.Height);

                            slot.Name.LocationFloat = new DevExpress.Utils.PointFloat(posX, slot.Name.LocationFloat.Y);
                            slot.Name.SizeF = new System.Drawing.SizeF(colWidth, slot.Name.SizeF.Height);
                        }
                    }
                }
            }
        }
        private void ApplyTextConfig(XRLabel label, TextConfig? cfg)
        {
            if (label == null || cfg == null) return;
            if (!string.IsNullOrEmpty(cfg.Text)) label.Text = cfg.Text;
            DXFontStyle style = DXFontStyle.Regular;
            if (cfg.Bold == true) style |= DXFontStyle.Bold;
            if (cfg.Italic == true) style |= DXFontStyle.Italic;
            string fontName = !string.IsNullOrEmpty(cfg.FontFamily) ? cfg.FontFamily : label.Font.Name;
            float fontSize = cfg.FontSize > 0 ? cfg.FontSize : label.Font.Size;
            label.Font = new DXFont(fontName, fontSize, style);
            if (Enum.TryParse<TextAlignment>(cfg.Alignment, true, out var align))
            {
                label.TextAlignment = align;
            }
        }
        private void ApplyTableStyle(XRTable table, GridStyleConfig? cfg)
        {
            if (table == null || cfg == null) return;
            DXFontStyle style = cfg.Bold ? DXFontStyle.Bold : DXFontStyle.Regular;
            string fontName = !string.IsNullOrEmpty(cfg.FontFamily) ? cfg.FontFamily : table.Font.Name;
            float fontSize = cfg.FontSize > 0 ? cfg.FontSize : table.Font.Size;
            table.Font = new DXFont(fontName, fontSize, style);
        }
    }
}
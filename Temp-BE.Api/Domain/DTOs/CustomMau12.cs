namespace Temp_BE.Api.Domain.DTOs
{
    public class ReportConfigDto
    {
        public SetupTrangDto? SetUpTrang { get; set; }
        public HeaderDto? Header { get; set; }
        public GridDto? Grid { get; set; }
        public FooterDto? Footer { get; set; }
    }

    public class SetupTrangDto
    {
        public string? KhoGiay { get; set; }
        public int CanLeTop { get; set; }
        public int CanLeBottom { get; set; }
        public int CanLeLeft { get; set; }
        public int CanLeRight { get; set; }
    }

    public class HeaderDto
    {
        public TextConfig? TenDonVi { get; set; }
        public TextConfig? CoSoChiTra { get; set; }
        public ThangNamConfig? ThangNam { get; set; }
        public TextConfig? HinhThucChiTra { get; set; }
        public TextConfig? NguonKinhPhi { get; set; }
    }

    public class TextConfig
    {
        public string? Text { get; set; }
        public string? FontFamily { get; set; }
        public int FontSize { get; set; }
        public bool? Bold { get; set; }
        public bool? Italic { get; set; }
        public string? Alignment { get; set; }
    }

    public class ThangNamConfig
    {
        public int? Thang { get; set; }
        public int? Nam { get; set; }
        public string? FontFamily { get; set; }
        public int FontSize { get; set; }
        public bool? Bold { get; set; }
        public bool? Italic { get; set; }
        public string? Alignment { get; set; }
    }

    public class GridDto
    {
        public GridStyleConfig? HeaderRow { get; set; }
        public GridStyleConfig? GroupHeader { get; set; }
        public GridStyleConfig? DataRow { get; set; }
        public GridStyleConfig? SummaryRow { get; set; }
    }

    public class GridStyleConfig
    {
        public string? FontFamily { get; set; }
        public int FontSize { get; set; }
        public bool Bold { get; set; }
    }

    public class FooterDto
    {
        public FooterStyleConfig? NgayThang { get; set; }
        public TextConfig? StyleChungNguoiKy { get; set; }
        public List<NguoiKyDto>? DanhSachNguoiKy { get; set; }
    }

    public class FooterStyleConfig
    {
        public string? FontFamily { get; set; }
        public int FontSize { get; set; }
        public bool Italic { get; set; }
        public string? Alignment { get; set; }
    }

    public class NguoiKyDto
    {
        public int Id { get; set; }
        public string? TenNguoiKy { get; set; }
        public string? ChucDanh { get; set; }
        public string? TieuDeNguoiKy { get; set; }
        public bool HienThi { get; set; }
    }
}

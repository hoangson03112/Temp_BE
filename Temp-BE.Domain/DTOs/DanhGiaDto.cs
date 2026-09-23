namespace Temp_BE.Domain.DTOs
{
    public class DanhGiaDto
    {
        public long Id { get; set; }
        public required string MaSp { get; set; }
        public int SoSao { get; set; }
        public string? NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
    }
    public class CreateDanhGiaDto
    {
        public int SoSao { get; set; }
        public string? NoiDung { get; set; }
    }
    public class UpdateDanhGiaDto
    {
        public int SoSao { get; set; }
        public string? NoiDung { get; set; }
    }
}

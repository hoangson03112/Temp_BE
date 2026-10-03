namespace Temp_BE.Domain.Requests
{
    public class CreateDanhGiaRequest
    {
        public int SoSao { get; set; }
        public string? NoiDung { get; set; }
    }
    public class UpdateDanhGiaRequest
    {
        public int SoSao { get; set; }
        public string? NoiDung { get; set; }
    }
}

namespace Temp_BE.Domain.Responses
{
    public class ReportResult
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = "application/pdf";
        public byte[] Bytes { get; set; } = Array.Empty<byte>();
        public int TotalPages { get; set; }
        public long FileSize => Bytes.Length;
        public string Base64 => Convert.ToBase64String(Bytes);
        public string DataUrl => $"data:{ContentType};base64,{Base64}";
    }
}
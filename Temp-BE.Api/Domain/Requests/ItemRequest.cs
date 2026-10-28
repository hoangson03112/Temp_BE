namespace Temp_BE.Api.Domain.Requests
{
    public class ItemRequest
    {
        public int skip { get; set; } = 0;
        public int take { get; set; } = 10;
        public string? search { get; set; }
    }
}

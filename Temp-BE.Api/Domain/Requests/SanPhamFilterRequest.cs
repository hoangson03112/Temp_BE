using Temp_BE.Domain.Common;

namespace Temp_BE.Domain.Requests
{
    public class SanPhamFilterRequest : SearchRequest
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? TrangThai { get; set; }
    }
}

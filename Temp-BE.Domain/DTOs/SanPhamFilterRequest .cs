using Temp_BE.Domain.Common;

namespace Temp_BE.Domain.DTOs
{
    public class SanPhamFilterRequest : PagedRequest
    {
        public decimal? MinPrice { get; set; } 
        public decimal? MaxPrice { get; set; } 
        public decimal? TrangThai { get; set; } 
    }
}
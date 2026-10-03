namespace Temp_BE.Domain.Common
{
    public class PagedRequest
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;
        private int _pageIndex = 1;
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value <= 0 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : (value <= 0 ? 10 : value);
        }
    }

    public class SearchRequest : PagedRequest
    {
        public string? Keyword { get; set; }
        public string? SortBy { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}

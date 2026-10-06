namespace Temp_BE.Domain.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public long Total { get; set; }

        public PagedResult() { }

        public PagedResult(List<T> items, long total)
        {
            Items = items;
            Total = total;
        }
    }
}
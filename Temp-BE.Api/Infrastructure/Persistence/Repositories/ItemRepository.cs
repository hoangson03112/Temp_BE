using NetCore.Oracle.DataAccess;
using Temp_BE.Api.Application.Interface.Repositories;
using Temp_BE.Api.Domain.DTOs;
using Temp_BE.Api.Domain.Requests;
using Temp_BE.Api.Infrastructure.Persistence.DbMappings;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.Common;

namespace Temp_BE.Api.Infrastructure.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbSession<DbQLBH> _db;
        public ItemRepository(IDbSession<DbQLBH> db) { _db = db; }

        public async Task<PagedResult<ItemDto>> GetItems(ItemRequest req, CancellationToken ct = default)
        {
            var keyword = string.IsNullOrWhiteSpace(req.search) ? null : req.search.Trim();
            var skip = req.skip < 0 ? 0 : req.skip;
            var take = req.take <= 0 ? 10 : req.take;

            var filtered =
                from x in _db.GetAll<ItemDb>()
                where (x.Ma.RegexpLike(keyword, "i") || x.Ten.RegexpLike(keyword, "i")).IfGenerateQuery(keyword != null)
                select x;

            var countRows = await _db.ToListAsync(
                from x in filtered
                select new { total = 1.Count() },
                isMapping: false, ct: ct);

            var total = (long)(countRows.FirstOrDefault()?.total ?? 0);
            if (total == 0)
            {
                return new PagedResult<ItemDto>(new List<ItemDto>(), 0);
            }

            var numberedQuery =
                from x in filtered
                select new
                {
                    RowNumber = x.RowNumber(() => x.Ma),
                    x.Ma,
                    x.Ten
                };

            var pageQuery =
                from a in numberedQuery
                where a.RowNumber > skip && a.RowNumber <= skip + take
                orderby a.RowNumber
                select new ItemDto
                {
                    Ma = a.Ma,
                    Ten = a.Ten
                };

            var items = await _db.ToListAsync(pageQuery, isMapping: false, ct: ct);

            return new PagedResult<ItemDto>
            {
                Items = items,
                Total = total
            };
        }
    }
}

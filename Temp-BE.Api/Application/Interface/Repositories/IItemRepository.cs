using Temp_BE.Api.Domain.DTOs;
using Temp_BE.Api.Domain.Requests;
using Temp_BE.Domain.Common;

namespace Temp_BE.Api.Application.Interface.Repositories
{
    public interface IItemRepository
    {
        Task<PagedResult<ItemDto>> GetItems(ItemRequest req, CancellationToken ct = default);

    }
}

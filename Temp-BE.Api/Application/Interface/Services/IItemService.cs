using Temp_BE.Api.Domain.DTOs;
using Temp_BE.Api.Domain.Requests;
using Temp_BE.Application.Common;
using Temp_BE.Domain.Common;

namespace Temp_BE.Api.Application.Interface.Services
{
    public interface IItemService
    {
        Task<ApiResponse<PagedResult<ItemDto>>> GetItemsAsync(ItemRequest req, CancellationToken ct = default);

    }
}

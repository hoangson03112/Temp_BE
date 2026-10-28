using Temp_BE.Api.Application.Interface.Repositories;
using Temp_BE.Api.Application.Interface.Services;
using Temp_BE.Api.Domain.DTOs;
using Temp_BE.Api.Domain.Requests;
using Temp_BE.Application.Common;
using Temp_BE.Domain.Common;

namespace Temp_BE.Api.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;
        public ItemService(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<ApiResponse<PagedResult<ItemDto>>> GetItemsAsync(ItemRequest req, CancellationToken ct = default)
        {
            var pagedResult = await _itemRepo.GetItems(req, ct);
            return ApiResponse<PagedResult<ItemDto>>.Ok(pagedResult, "Lấy danh sách thành công.");
        }
    }
}

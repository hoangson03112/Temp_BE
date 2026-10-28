using Microsoft.AspNetCore.Mvc;
using Temp_BE.Api.Application.Interface.Services;
using Temp_BE.Api.Domain.Requests;

namespace Temp_BE.Api.Controllers
{
    [Route("api/item")]

    public class ItemController : BaseApiController
    {
        private readonly IItemService _itemSvc;
        public ItemController(IItemService itemSvc)
        {
            _itemSvc = itemSvc;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedList([FromQuery] ItemRequest request, CancellationToken ct = default)
        {
            var result = await _itemSvc.GetItemsAsync(request, ct);
            return HandleResult(result);
        }

    }
}

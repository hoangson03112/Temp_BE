using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Api.Controllers
{
    [Route("api/don-hang")]
    public class DonHangController : BaseApiController
    {
        private readonly IDonHangService _donHangService;
        public DonHangController(IDonHangService service)
        {
            _donHangService = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateDonHangRequest req, CancellationToken ct)
        {
            if (!long.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out long userId))
                return Unauthorized();

            var result = await _donHangService.CreateOrderAsync(userId, req);
            return HandleResult(result);
        }

        [HttpGet("my-orders")]
        [Authorize]
        public async Task<IActionResult> GetMyOrders([FromQuery] PagedRequest request, CancellationToken ct)
        {
            if (!long.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out long userId))
                return Unauthorized();

            var result = await _donHangService.GetPagedListAsync(userId, request, ct);
            return HandleResult(result);
        }

        [HttpGet("{maDh}")]
        [Authorize]
        public async Task<IActionResult> GetById(string maDh)
        {
            var result = await _donHangService.GetOrderByIdAsync(maDh);
            return HandleResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? status, [FromQuery] PagedRequest req, CancellationToken ct)
        {
            var result = await _donHangService.GetAllOrdersAsync(status, req, ct);
            return HandleResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{maDh}/status")]
        public async Task<IActionResult> UpdateStatus(string maDh, [FromBody] UpdateOrderStatusRequest req)
        {
            var result = await _donHangService.UpdateStatusAsync(maDh, req.TrangThai);
            return HandleResult(result);
        }
    }
}
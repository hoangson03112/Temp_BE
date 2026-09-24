using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;

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
        public async Task<IActionResult> Create([FromBody] CreateDonHangDto dto)
        {
            var userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _donHangService.CreateOrderAsync(userId, dto);
            return HandleResult(result);
        }
        [HttpGet("my-orders")]
        [Authorize]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _donHangService.GetMyOrdersAsync(userId);
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? status)
        {
            var result = await _donHangService.GetAllOrdersAsync(status);
            return HandleResult(result);
        }
        [Authorize(Roles = "Admin")]
        [Authorize]
        [HttpPut("{maDh}/status")]
        public async Task<IActionResult> UpdateStatus(string maDh, [FromBody] UpdateOrderStatusDto dto)
        {
            var result = await _donHangService.UpdateStatusAsync(maDh, dto.TrangThai);
            return HandleResult(result);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Api.Controllers
{
    [Route("api/san-pham")]
    public class SanPhamController : BaseApiController
    {

        private readonly ISanPhamService _sanPhamService;

        public SanPhamController(ISanPhamService sanPhamService)
        {
            _sanPhamService = sanPhamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sanPhamService.GetAllAsync();
            return HandleResult(result);
        }

        [HttpGet("{maSp}")]
        public async Task<IActionResult> GetById(string maSp)
        {
            var result = await _sanPhamService.GetByMaSpAsync(maSp);
            return HandleResult(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSanPhamDto dto)
        {
            var result = await _sanPhamService.CreateAsync(dto);
            return HandleResult(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string maSp, [FromBody] UpdateSanPhamDto dto)
        {
            var result = await _sanPhamService.UpdateAsync(maSp, dto);
            return HandleResult(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{maSp}")]
        public async Task<IActionResult> Delete(string maSp)
        {
            var result = await _sanPhamService.DeleteAsync(maSp);
            return HandleResult(result);
        }
    }
}
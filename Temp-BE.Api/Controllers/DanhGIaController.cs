using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Api.Controllers
{
    [Route("api/danh-gia")]
    public class DanhGiaController : BaseApiController
    {
        private readonly IDanhGiaService _danhGiaService;
        public DanhGiaController(IDanhGiaService danhGiaService)
        {
            _danhGiaService = danhGiaService;
        }

        [HttpGet("{maSp}")]
        public async Task<IActionResult> GetAll(string maSp)
        {
            var result = await _danhGiaService.GetByMaSpAsync(maSp);
            return HandleResult(result);
        }

        [Authorize]
        [HttpPost("{maSp}")]
        public async Task<IActionResult> Create(string maSp, [FromBody] CreateDanhGiaRequest req)
        {
            var result = await _danhGiaService.CreateAsync(maSp, req);
            return HandleResult(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateDanhGiaRequest req)
        {
            var result = await _danhGiaService.UpdateAsync(id, req);
            return HandleResult(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _danhGiaService.DeleteAsync(id);
            return HandleResult(result);
        }
    }
}

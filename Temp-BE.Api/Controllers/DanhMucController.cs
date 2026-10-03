using Microsoft.AspNetCore.Mvc;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Api.Controllers
{

    [Route("api/danh-muc")]
    public class DanhMucController : BaseApiController
    {
        private readonly IDanhMucService _danhMucService;
        public DanhMucController(IDanhMucService service)
        {
            _danhMucService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _danhMucService.GetAllAsync();
            return HandleResult(result);
        }
        [HttpGet("{maDm}")]
        public async Task<IActionResult> GetByMaDm(string maDm)
        {
            var result = await _danhMucService.GetByMaDmAsync(maDm);
            return HandleResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDanhMucRequest req)
        {
            var result = await _danhMucService.CreateAsync(req);
            return HandleResult(result);
        }
        [HttpPut("{maDm}")]
        public async Task<IActionResult> Update(string maDm, [FromBody] UpdateDanhMucRequest req)
        {
            var result = await _danhMucService.UpdateAsync(maDm, req);
            return HandleResult(result);
        }
        [HttpDelete("{maDm}")]
        public async Task<IActionResult> Delete(string maDm)
        {
            var result = await _danhMucService.DeleteAsync(maDm);
            return HandleResult(result);
        }

    }
}

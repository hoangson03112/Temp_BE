using Temp_BE.Application.Common;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Services
{
    public class DanhMucService : IDanhMucService
    {
        private readonly IDanhMucRepository _repo;
        public DanhMucService(IDanhMucRepository repo) { _repo = repo; }

        public async Task<ApiResponse<PagedResult<DanhMucDto>>> GetPagedListAsync(PagedRequest req, CancellationToken ct = default)
        {
            var data = await _repo.GetPagedListAsync(req, ct);
            return ApiResponse<PagedResult<DanhMucDto>>.Ok(data, "Lấy danh sách danh mục thành công.");
        }

        public async Task<ApiResponse<DanhMucDto>> GetByMaDmAsync(string maDm)
        {
            var item = await _repo.GetByIdAsync(maDm);
            if (item == null) return ApiResponse<DanhMucDto>.Fail(404, $"Không tìm thấy danh mục '{maDm}'.");
            return ApiResponse<DanhMucDto>.Ok(item);
        }

        public async Task<ApiResponse<DanhMucDto>> CreateAsync(CreateDanhMucRequest req)
        {
            var item = await _repo.CreateAsync(req);
            return ApiResponse<DanhMucDto>.Created(item, "Tạo danh mục thành công.");
        }

        public async Task<ApiResponse<DanhMucDto>> UpdateAsync(string maDm, UpdateDanhMucRequest req)
        {
            var item = await _repo.UpdateAsync(maDm, req);
            if (item == null) return ApiResponse<DanhMucDto>.Fail(404, $"Không tìm thấy danh mục '{maDm}'.");
            return ApiResponse<DanhMucDto>.Ok(item, "Cập nhật thành công.");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(string maDm)
        {
            if (!await _repo.ExistsAsync(maDm))
                return ApiResponse<bool>.Fail(404, $"Không tìm thấy danh mục '{maDm}'.");

            await _repo.DeleteAsync(maDm);
            return ApiResponse<bool>.Ok(true, "Xóa danh mục thành công.");
        }
    }
}
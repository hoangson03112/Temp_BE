using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Services
{
    public class DanhMucService : IDanhMucService
    {
        private readonly IDanhMucRepository _repo;
        public DanhMucService(IDanhMucRepository repo) { _repo = repo; }

        public async Task<ApiResponse<List<DanhMucDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return ApiResponse<List<DanhMucDto>>.Ok(data, "Lấy danh sách danh mục thành công.");
        }

        public async Task<ApiResponse<DanhMucDto>> GetByMaDmAsync(string maDm)
        {
            var item = await _repo.GetByIdAsync(maDm);
            if (item == null) return ApiResponse<DanhMucDto>.Fail(404, $"Không tìm thấy danh mục '{maDm}'.");
            return ApiResponse<DanhMucDto>.Ok(item);
        }

        public async Task<ApiResponse<DanhMucDto>> CreateAsync(CreateDanhMucDto dto)
        {
            var item = await _repo.CreateAsync(dto);
            return ApiResponse<DanhMucDto>.Created(item, "Tạo danh mục thành công.");
        }

        public async Task<ApiResponse<DanhMucDto>> UpdateAsync(string maDm, UpdateDanhMucDto dto)
        {
            var item = await _repo.UpdateAsync(maDm, dto);
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
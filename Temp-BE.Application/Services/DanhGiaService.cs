using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Services
{
    public class DanhGiaService : IDanhGiaService
    {
        private readonly IDanhGiaRepository _repo;
        public DanhGiaService(IDanhGiaRepository repo)
        {
            _repo = repo;
        }
        public async Task<ApiResponse<List<DanhGiaDto>>> GetByMaSp(string maSp)
        {
            var items = await _repo.GetByMaSpAsync(maSp);
            return ApiResponse<List<DanhGiaDto>>.Ok(items, "Lấy đánh giá của sản phẩm thành công.");
        }
        public async Task<ApiResponse<DanhGiaDto>> CreateAsync(string maSp, CreateDanhGiaDto dto)
        {
            var item = await _repo.CreateAsync(maSp, dto);
            return ApiResponse<DanhGiaDto>.Ok(item, "Tạo thành công");
        }
        public async Task<ApiResponse<DanhGiaDto>> UpdateAsync(long id, UpdateDanhGiaDto dto)
        {
            if (dto.SoSao < 1 || dto.SoSao > 5)
            {
                return ApiResponse<DanhGiaDto>.Fail(400, "Số sao đánh giá phải từ 1 đến 5 sao.");
            }
            var item = await _repo.UpdateAsync(id, dto);
            if (item == null)
            {
                return ApiResponse<DanhGiaDto>.Fail(404, $"Không tìm thấy đánh giá có mã ID {id}.");
            }
            return ApiResponse<DanhGiaDto>.Ok(item, "Cập nhật đánh giá thành công.");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(long id)
        {
            var exists = await _repo.ExistsAsync(id);
            if (!exists)
            {
                return ApiResponse<bool>.Fail(404, $"Không tìm thấy đánh giá có ID {id} để xoá.");
            }
            await _repo.DeleteAsync(id);
            return ApiResponse<bool>.Ok(true, "Xoá đánh giá thành công.");
        }
    }
}

using Temp_BE.Application.Common;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Services
{
    public class DanhGiaService : IDanhGiaService
    {
        private readonly IDanhGiaRepository _repo;
        public DanhGiaService(IDanhGiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<List<DanhGiaDto>>> GetByMaSpAsync(string maSp)
        {
            var items = await _repo.GetByMaSpAsync(maSp);
            return ApiResponse<List<DanhGiaDto>>.Ok(items, "Lấy đánh giá của sản phẩm thành công.");
        }

        public async Task<ApiResponse<DanhGiaDto>> CreateAsync(string maSp, CreateDanhGiaRequest req)
        {
            if (req.SoSao < 1 || req.SoSao > 5)
            {
                return ApiResponse<DanhGiaDto>.Fail(400, "Số sao đánh giá phải từ 1 đến 5 sao.");
            }

            var item = await _repo.CreateAsync(maSp, req);
            return ApiResponse<DanhGiaDto>.Created(item, "Tạo đánh giá thành công.");
        }

        public async Task<ApiResponse<DanhGiaDto>> UpdateAsync(long id, UpdateDanhGiaRequest req)
        {
            if (req.SoSao < 1 || req.SoSao > 5)
            {
                return ApiResponse<DanhGiaDto>.Fail(400, "Số sao đánh giá phải từ 1 đến 5 sao.");
            }

            var item = await _repo.UpdateAsync(id, req);
            if (item == null)
            {
                return ApiResponse<DanhGiaDto>.Fail(404, $"Không tìm thấy đánh giá có ID {id}.");
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

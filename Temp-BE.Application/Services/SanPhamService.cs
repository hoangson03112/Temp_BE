using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Services
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _sanPhamRepo;
        public SanPhamService(ISanPhamRepository sanPhamRepo)
        {
            _sanPhamRepo = sanPhamRepo;
        }
        public async Task<ApiResponse<PagedResult<SanPhamDto>>> GetPagedListAsync(SanPhamFilterRequest request)
        {
            var pagedResult = await _sanPhamRepo.GetPagedListAsync(request);
            return ApiResponse<PagedResult<SanPhamDto>>.Ok(pagedResult, "Lấy danh sách sản phẩm thành công.");
        }
        public async Task<ApiResponse<SanPhamDto>> GetByMaSpAsync(string maSp)
        {
            var item = await _sanPhamRepo.GetByMaSpAsync(maSp);
            if (item == null)
            {
                return ApiResponse<SanPhamDto>.Fail(404, $"Không tìm thấy sản phẩm có mã '{maSp}'.");
            }
            return ApiResponse<SanPhamDto>.Ok(item, "Lấy chi tiết sản phẩm thành công.");
        }
        public async Task<ApiResponse<SanPhamDto>> CreateAsync(CreateSanPhamDto dto)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.TenSp))
                errors.Add("Tên sản phẩm không được để trống.");
            if (dto.GiaBan <= 0)
                errors.Add("Giá bán phải lớn hơn 0.");
            if (errors.Count > 0)
            {
                return ApiResponse<SanPhamDto>.Fail(400, "Dữ liệu không hợp lệ.", errors);
            }
            var createdItem = await _sanPhamRepo.CreateAsync(dto);
            return ApiResponse<SanPhamDto>.Created(createdItem, "Thêm mới sản phẩm thành công.");
        }
        public async Task<ApiResponse<SanPhamDto>> UpdateAsync(string maSp, UpdateSanPhamDto dto)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.TenSp))
                errors.Add("Tên sản phẩm không được để trống.");
            if (dto.GiaBan <= 0)
                errors.Add("Giá bán phải lớn hơn 0.");
            if (errors.Count > 0)
            {
                return ApiResponse<SanPhamDto>.Fail(400, "Dữ liệu không hợp lệ.", errors);
            }
            var updatedItem = await _sanPhamRepo.UpdateAsync(maSp, dto);
            if (updatedItem == null)
            {
                return ApiResponse<SanPhamDto>.Fail(404, $"Không tìm thấy sản phẩm có mã '{maSp}'.");
            }
            return ApiResponse<SanPhamDto>.Ok(updatedItem, "Cập nhật sản phẩm thành công.");
        }
        public async Task<ApiResponse<bool>> DeleteAsync(string maSp)
        {
            var exists = await _sanPhamRepo.ExistsAsync(maSp);
            if (!exists)
            {
                return ApiResponse<bool>.Fail(404, $"Không tìm thấy sản phẩm có mã '{maSp}' để xoá.");
            }
            await _sanPhamRepo.DeleteAsync(maSp);
            return ApiResponse<bool>.Ok(true, $"Xoá thành công sản phẩm '{maSp}'.");
        }
    }
}

using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Interface.Services
{
    public interface ISanPhamService
    {
        Task<ApiResponse<List<SanPhamDto>>> GetAllAsync();
        Task<ApiResponse<SanPhamDto>> GetByMaSpAsync(string maSp);
        Task<ApiResponse<SanPhamDto>> CreateAsync(CreateSanPhamDto dto);
        Task<ApiResponse<SanPhamDto>> UpdateAsync(string maSp, UpdateSanPhamDto dto);
        Task<ApiResponse<bool>> DeleteAsync(string maSp);
    }
}
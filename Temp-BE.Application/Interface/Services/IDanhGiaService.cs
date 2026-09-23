using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Interface.Services
{
    public interface IDanhGiaService
    {
        Task<ApiResponse<List<DanhGiaDto>>> GetByMaSp(string maSp);
        Task<ApiResponse<DanhGiaDto>> CreateAsync(string maSp, CreateDanhGiaDto dto);
        Task<ApiResponse<DanhGiaDto>> UpdateAsync(long id, UpdateDanhGiaDto dto);
        Task<ApiResponse<bool>> DeleteAsync(long id);
    }
}

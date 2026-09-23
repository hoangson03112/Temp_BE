using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Interface.Services
{
    public interface IDanhMucService
    {
        Task<ApiResponse<List<DanhMucDto>>> GetAllAsync();
        Task<ApiResponse<DanhMucDto>> GetByMaDmAsync(string maDm);
        Task<ApiResponse<DanhMucDto>> CreateAsync(CreateDanhMucDto dto);
        Task<ApiResponse<DanhMucDto>> UpdateAsync(string maDm, UpdateDanhMucDto dto);
        Task<ApiResponse<bool>> DeleteAsync(string maDm);
    }
}

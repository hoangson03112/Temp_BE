using Temp_BE.Application.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Services
{
    public interface IDanhMucService
    {
        Task<ApiResponse<List<DanhMucDto>>> GetAllAsync();
        Task<ApiResponse<DanhMucDto>> GetByMaDmAsync(string maDm);
        Task<ApiResponse<DanhMucDto>> CreateAsync(CreateDanhMucRequest req);
        Task<ApiResponse<DanhMucDto>> UpdateAsync(string maDm, UpdateDanhMucRequest req);
        Task<ApiResponse<bool>> DeleteAsync(string maDm);
    }
}

using Temp_BE.Application.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Services
{
    public interface IDanhGiaService
    {
        Task<ApiResponse<List<DanhGiaDto>>> GetByMaSp(string maSp);
        Task<ApiResponse<DanhGiaDto>> CreateAsync(string maSp, CreateDanhGiaRequest req);
        Task<ApiResponse<DanhGiaDto>> UpdateAsync(long id, UpdateDanhGiaRequest req);
        Task<ApiResponse<bool>> DeleteAsync(long id);
    }
}

using Temp_BE.Application.Common;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Services
{
    public interface ISanPhamService
    {
        Task<ApiResponse<PagedResult<SanPhamDto>>> GetPagedListAsync(SanPhamFilterRequest req, CancellationToken ct = default);
        Task<ApiResponse<SanPhamDto>> GetByMaSpAsync(string maSp);
        Task<ApiResponse<SanPhamDto>> CreateAsync(CreateSanPhamRequest req);
        Task<ApiResponse<SanPhamDto>> UpdateAsync(string maSp, UpdateSanPhamRequest req);
        Task<ApiResponse<bool>> DeleteAsync(string maSp);
    }
}
using Temp_BE.Application.Common;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Services
{
    public interface IDonHangService
    {
        Task<ApiResponse<DonHangDto>> CreateOrderAsync(long userId, CreateDonHangRequest req);
        Task<ApiResponse<PagedResult<DonHangDto>>> GetPagedListAsync(long userId, PagedRequest request, CancellationToken ct = default);
        Task<ApiResponse<PagedResult<DonHangDto>>> GetAllOrdersAsync(int? trangThai, PagedRequest request, CancellationToken ct = default);
        Task<ApiResponse<DonHangDto>> GetOrderByIdAsync(string maDh);
        Task<ApiResponse<bool>> UpdateStatusAsync(string maDh, int trangThai);
    }
}

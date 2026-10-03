using Temp_BE.Application.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Services
{
    public interface IDonHangService
    {
        Task<ApiResponse<DonHangDto>> CreateOrderAsync(long userId, CreateDonHangRequest req);
        Task<ApiResponse<List<DonHangDto>>> GetMyOrdersAsync(long userId);
        Task<ApiResponse<List<DonHangDto>>> GetAllOrdersAsync(int? trangThai);
        Task<ApiResponse<DonHangDto>> GetOrderByIdAsync(string maDh);
        Task<ApiResponse<bool>> UpdateStatusAsync(string maDh, int trangThai);
    }
}

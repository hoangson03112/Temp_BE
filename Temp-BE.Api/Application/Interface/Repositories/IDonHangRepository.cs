using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IDonHangRepository
    {
        Task<DonHangDto> CreateOrderAsync(long userId, CreateDonHangRequest req, List<CreateChiTietDonHangRequest> sanPhamList);
        Task<List<DonHangDto>> GetOrdersByUserAsync(long userId);
        Task<List<DonHangDto>> GetAllOrdersAsync(int? trangThai);
        Task<DonHangDto?> GetOrderByIdAsync(string maDh);
        Task<bool> UpdateStatusAsync(string maDh, int trangThai);
    }
}

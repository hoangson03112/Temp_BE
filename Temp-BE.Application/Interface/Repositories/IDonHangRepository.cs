using Temp_BE.Domain.DTOs;

public interface IDonHangRepository
{
    Task<DonHangDto> CreateOrderAsync(long userId, CreateDonHangDto dto, List<CreateChiTietDonHangDto> sanPhamList);
    Task<List<DonHangDto>> GetOrdersByUserAsync(long userId);
    Task<List<DonHangDto>> GetAllOrdersAsync(int? trangThai);
    Task<DonHangDto?> GetOrderByIdAsync(string maDh);
    Task<bool> UpdateStatusAsync(string maDh, int trangThai);
}

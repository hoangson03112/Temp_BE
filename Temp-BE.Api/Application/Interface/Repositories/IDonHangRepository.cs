using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IDonHangRepository
    {
        Task<DonHangDto> CreateOrderAsync(long userId, CreateDonHangRequest req, List<CreateChiTietDonHangRequest> sanPhamList);
        Task<PagedResult<DonHangDto>> GetPagedListAsync(long userId, PagedRequest request, CancellationToken ct = default);
        Task<PagedResult<DonHangDto>> GetAllOrdersAsync(int? trangThai, PagedRequest request, CancellationToken ct = default);
        Task<DonHangDto?> GetOrderByIdAsync(string maDh);
        Task<bool> UpdateStatusAsync(string maDh, int trangThai);
    }
}

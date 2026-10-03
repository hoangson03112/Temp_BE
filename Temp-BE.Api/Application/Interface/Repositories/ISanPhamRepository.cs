using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;
namespace Temp_BE.Application.Interface.Repositories
{
    public interface ISanPhamRepository
    {
        Task<PagedResult<SanPhamDto>> GetPagedListAsync(SanPhamFilterRequest req, CancellationToken ct);
        Task<SanPhamDto?> GetByMaSpAsync(string maSp);
        Task<SanPhamDto> CreateAsync(CreateSanPhamRequest req);
        Task<SanPhamDto?> UpdateAsync(string maSp, UpdateSanPhamRequest req);
        Task<bool> DeleteAsync(string maSp);
        Task<bool> ExistsAsync(string maSp);
        Task DeductStockAsync(string maSp, decimal soLuong);
    }
}
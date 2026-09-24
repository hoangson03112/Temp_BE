using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
namespace Temp_BE.Application.Interface.Repositories
{
    public interface ISanPhamRepository
    {
        Task<PagedResult<SanPhamDto>> GetPagedListAsync(SanPhamFilterRequest request);
        Task<SanPhamDto?> GetByMaSpAsync(string maSp);
        Task<SanPhamDto> CreateAsync(CreateSanPhamDto dto);
        Task<SanPhamDto?> UpdateAsync(string maSp, UpdateSanPhamDto dto);
        Task<bool> DeleteAsync(string maSp);
        Task<bool> ExistsAsync(string maSp);
    }
}
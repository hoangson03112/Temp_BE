using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IDanhGiaRepository
    {
        Task<List<DanhGiaDto>> GetByMaSpAsync(string maSp);
        Task<DanhGiaDto> CreateAsync(string maSp, CreateDanhGiaDto dto);
        Task<DanhGiaDto?> UpdateAsync(long id, UpdateDanhGiaDto dto);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
    }
}

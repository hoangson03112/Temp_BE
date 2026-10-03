using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IDanhGiaRepository
    {
        Task<List<DanhGiaDto>> GetByMaSpAsync(string maSp);
        Task<DanhGiaDto> CreateAsync(string maSp, CreateDanhGiaRequest req);
        Task<DanhGiaDto?> UpdateAsync(long id, UpdateDanhGiaRequest req);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
    }
}

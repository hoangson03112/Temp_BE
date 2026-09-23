using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IDanhMucRepository
    {
        Task<List<DanhMucDto>> GetAllAsync();
        Task<DanhMucDto?> GetByIdAsync(string maDm);
        Task<DanhMucDto> CreateAsync(CreateDanhMucDto dto);
        Task<DanhMucDto?> UpdateAsync(string maDm, UpdateDanhMucDto dto);
        Task<bool> DeleteAsync(string maDm);
        Task<bool> ExistsAsync(string maDm);
    }
}

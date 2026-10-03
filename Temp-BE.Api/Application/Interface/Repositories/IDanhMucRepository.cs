using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IDanhMucRepository
    {
        Task<List<DanhMucDto>> GetAllAsync();
        Task<DanhMucDto?> GetByIdAsync(string maDm);
        Task<DanhMucDto> CreateAsync(CreateDanhMucRequest req);
        Task<DanhMucDto?> UpdateAsync(string maDm, UpdateDanhMucRequest req);
        Task<bool> DeleteAsync(string maDm);
        Task<bool> ExistsAsync(string maDm);
    }
}

using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IAuthRepository
    {
        Task<UserDto?> GetByUserNameOrEmailAsync(string identifier);
        Task<UserDto?> GetByIdAsync(long id);
        Task<bool> ExistsByUserNameOrEmailAsync(string userName, string email);
        Task<UserDto> CreateAsync(UserDto user);
    }
}

using Temp_BE.Domain.Models;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IAuthRepository
    {
        Task<UserAccount?> GetByUserNameOrEmailAsync(string identifier);
        Task<UserAccount?> GetByIdAsync(long id);
        Task<bool> ExistsByUserNameOrEmailAsync(string userName, string email);
        Task<UserAccount> CreateAsync(UserAccount user);
    }
}

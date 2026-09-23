using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Application.Interface.Repositories
{
    public interface IAuthRepository
    {
        Task<UserDb?> GetByUserNameOrEmailAsync(string identifier);
        Task<UserDb?> GetByIdAsync(long id);
        Task<bool> ExistsByUserNameOrEmailAsync(string userName, string email);
        Task<UserDb> CreateAsync(UserDb user);
    }
}

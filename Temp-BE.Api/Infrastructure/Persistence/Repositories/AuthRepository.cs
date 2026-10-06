using NetCore.Oracle.DataAccess;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.Models;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Infrastructure.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbSession<DbQLBH> _db;

        public AuthRepository(IDbSession<DbQLBH> db)
        {
            _db = db;
        }

        public async Task<UserAccount?> GetByUserNameOrEmailAsync(string identifier)
        {
            var entity = await _db.FirstOrDefaultAsync<UserDb>(
                from u in _db.GetAll<UserDb>()
                where u.UserName == identifier || u.Email == identifier
                select u
            );
            return ToModel(entity);
        }

        public async Task<UserAccount?> GetByIdAsync(long id)
        {
            var entity = await _db.FirstOrDefaultAsync<UserDb>(
                from u in _db.GetAll<UserDb>()
                where u.Id == id
                select u
            );
            return ToModel(entity);
        }

        public async Task<bool> ExistsByUserNameOrEmailAsync(string userName, string email)
        {
            var res = await _db.ToListAsync((
                from u in _db.GetAll<UserDb>()
                where u.UserName == userName || u.Email == email
                select u.Id
            ).Take(1));
            return res.Count > 0;
        }

        public async Task<UserAccount> CreateAsync(UserAccount user)
        {
            var entity = new UserDb
            {
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                FullName = user.FullName,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            };
            await _db.InsertAsync(entity);
            user.Id = entity.Id;
            return user;
        }

        private static UserAccount? ToModel(UserDb? entity)
        {
            if (entity == null) return null;
            return new UserAccount
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                FullName = entity.FullName,
                Role = entity.Role,
                IsActive = entity.IsActive,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
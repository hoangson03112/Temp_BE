using NetCore.Oracle.DataAccess;

namespace Temp_BE.Infrastructure.Persistence.DbMappings
{
    [MappingDb.TABLE_NAME("APP_USERS")]
    public class UserDb
    {
        [MappingDb.COLUMN_NAME("ID", sequence: "SEQ_APP_USERS")]
        public virtual long Id { get; set; }
        [MappingDb.COLUMN_NAME("USER_NAME")]
        public virtual string UserName { get; set; } = default!;
        [MappingDb.COLUMN_NAME("EMAIL")]
        public virtual string Email { get; set; } = default!;
        [MappingDb.COLUMN_NAME("PASSWORD_HASH")]
        public virtual string PasswordHash { get; set; } = default!;
        [MappingDb.COLUMN_NAME("FULL_NAME")]
        public virtual string? FullName { get; set; }
        [MappingDb.COLUMN_NAME("ROLE")]
        public virtual string Role { get; set; } = "Customer";
        [MappingDb.COLUMN_NAME("IS_ACTIVE")]
        public virtual int IsActive { get; set; } = 1;
        [MappingDb.COLUMN_NAME("CREATED_AT")]
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

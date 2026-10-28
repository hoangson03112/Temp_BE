using NetCore.Oracle.DataAccess;

namespace Temp_BE.Api.Infrastructure.Persistence.DbMappings
{


    [MappingDb.TABLE_NAME("ITEMS")]
    public class ItemDb
    {
        [MappingDb.COLUMN_NAME("CODE")]
        public virtual string Ma { get; set; } = string.Empty;
        [MappingDb.COLUMN_NAME("NAME")]
        public virtual string Ten { get; set; } = string.Empty;
    }

}

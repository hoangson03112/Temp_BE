using NetCore.Oracle.DataAccess;

namespace Temp_BE.Infrastructure.Persistence.DbMappings
{
    [MappingDb.TABLE_NAME("DANH_MUC")]
    public class DanhMucDb
    {
        [MappingDb.COLUMN_NAME("MA_DM", true)]
        public virtual string MaDm { get; set; } = default!;

        [MappingDb.COLUMN_NAME("TEN_DM")]
        public virtual string TenDm { get; set; } = default!;

        [MappingDb.COLUMN_NAME("MO_TA")]
        public virtual string? MoTa { get; set; }

        [MappingDb.COLUMN_NAME("TRANG_THAI")]
        public virtual int TrangThai { get; set; } = 1;
    }
}
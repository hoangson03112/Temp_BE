using NetCore.Oracle.DataAccess;

namespace Temp_BE.Infrastructure.Persistence.DbMappings
{
    [MappingDb.TABLE_NAME("SAN_PHAM")]
    public class SanPhamDb
    {
        [MappingDb.COLUMN_NAME("MA_SP", true)]
        public virtual string MaSp { get; set; } = default!;

        [MappingDb.COLUMN_NAME("TEN_SP")]
        public virtual string TenSp { get; set; } = default!;

        [MappingDb.COLUMN_NAME("GIA_BAN")]
        public virtual decimal GiaBan { get; set; }

        [MappingDb.COLUMN_NAME("SO_LUONG")]
        public virtual decimal? SoLuong { get; set; }

        [MappingDb.COLUMN_NAME("TRANG_THAI")]
        public virtual decimal? TrangThai { get; set; }
    }
}
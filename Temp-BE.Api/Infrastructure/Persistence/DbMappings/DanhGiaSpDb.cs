using NetCore.Oracle.DataAccess;

namespace Temp_BE.Infrastructure.Persistence.DbMappings
{
    [MappingDb.TABLE_NAME("DANH_GIA_SP")]
    public class DanhGiaSpDb
    {

        [MappingDb.COLUMN_NAME("ID", sequence: "SEQ_DANH_GIA_SP")]
        public virtual long Id { get; set; }

        [MappingDb.COLUMN_NAME("MA_SP")]
        public virtual string MaSp { get; set; } = default!;

        [MappingDb.COLUMN_NAME("SO_SAO")]
        public virtual int SoSao { get; set; }

        [MappingDb.COLUMN_NAME("NOI_DUNG")]
        public virtual string? NoiDung { get; set; }

        [MappingDb.COLUMN_NAME("NGAY_TAO")]
        public virtual DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
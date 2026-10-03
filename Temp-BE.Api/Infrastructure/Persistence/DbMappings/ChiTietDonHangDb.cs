using NetCore.Oracle.DataAccess;

namespace Temp_BE.Infrastructure.Persistence.DbMappings
{
    [MappingDb.TABLE_NAME("CHI_TIET_DON_HANG")]
    public class ChiTietDonHangDb
    {
        [MappingDb.COLUMN_NAME("ID", sequence: "SEQ_CHI_TIET_DON_HANG")]
        public virtual long Id { get; set; }

        [MappingDb.COLUMN_NAME("MA_DH")]
        public virtual string MaDh { get; set; } = default!;

        [MappingDb.COLUMN_NAME("MA_SP")]
        public virtual string MaSp { get; set; } = default!;

        [MappingDb.COLUMN_NAME("SO_LUONG")]
        public virtual decimal SoLuong { get; set; }

        [MappingDb.COLUMN_NAME("DON_GIA")]
        public virtual decimal DonGia { get; set; }

        [MappingDb.COLUMN_NAME("THANH_TIEN")]
        public virtual decimal ThanhTien { get; set; }
    }
}
using NetCore.Oracle.DataAccess;

namespace Temp_BE.Infrastructure.Persistence.DbMappings
{
    [MappingDb.TABLE_NAME("DON_HANG")]
    public class DonHangDb
    {
        [MappingDb.COLUMN_NAME("MA_DH", true)]
        public virtual string MaDh { get; set; } = default!;
        [MappingDb.COLUMN_NAME("USER_ID")]
        public virtual long UserId { get; set; }
        [MappingDb.COLUMN_NAME("TEN_NGUOI_NHAN")]
        public virtual string TenNguoiNhan { get; set; } = default!;
        [MappingDb.COLUMN_NAME("SO_DT")]
        public virtual string SoDt { get; set; } = default!;
        [MappingDb.COLUMN_NAME("DIA_CHI")]
        public virtual string DiaChi { get; set; } = default!;
        [MappingDb.COLUMN_NAME("TONG_TIEN")]
        public virtual decimal TongTien { get; set; }
        [MappingDb.COLUMN_NAME("TRANG_THAI")]
        public virtual int TrangThai { get; set; } = 0;
        [MappingDb.COLUMN_NAME("GHI_CHU")]
        public virtual string? GhiChu { get; set; }
        [MappingDb.COLUMN_NAME("NGAY_TAO")]
        public virtual DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
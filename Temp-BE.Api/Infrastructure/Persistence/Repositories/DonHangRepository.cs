using NetCore.Oracle.DataAccess;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Infrastructure.Persistence.Repositories
{

    public class DonHangRepository : IDonHangRepository
    {
        private readonly IDbSession<DbQLBH> _db;
        private readonly ISanPhamRepository _repo;
        public DonHangRepository(IDbSession<DbQLBH> db, ISanPhamRepository repo) { _db = db; _repo = repo; }

        public async Task<DonHangDto> CreateOrderAsync(long userId, CreateDonHangRequest req, List<CreateChiTietDonHangRequest> sanPhamList)
        {
            if (sanPhamList == null || !sanPhamList.Any())
            {
                throw new ArgumentException("Danh sách sản phẩm không được để trống.");
            }

            string maDh = $"DH{Guid.NewGuid():N}".Substring(0, 20).ToUpper();
            decimal tongTien = 0;

            var danhSachChiTietDb = new List<ChiTietDonHangDb>();
            var danhSachMonDto = new List<ChiTietDonHangDto>();

            foreach (var item in sanPhamList)
            {
                decimal donGia = item.DonGia;
                decimal thanhTien = donGia * item.SoLuong;
                tongTien += thanhTien;

                danhSachChiTietDb.Add(new ChiTietDonHangDb
                {
                    MaDh = maDh,
                    MaSp = item.MaSp,
                    SoLuong = item.SoLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                });

                danhSachMonDto.Add(new ChiTietDonHangDto
                {
                    MaSp = item.MaSp,
                    TenSp = item.TenSp,
                    SoLuong = item.SoLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                });
            }

            var donHang = new DonHangDb
            {
                MaDh = maDh,
                UserId = userId,
                TenNguoiNhan = req.TenNguoiNhan,
                SoDt = req.SoDt,
                DiaChi = req.DiaChi,
                TongTien = tongTien,
                TrangThai = 0,
                GhiChu = req.GhiChu,
                NgayTao = DateTime.Now
            };

            await using var scope = await _db.BeginScopeAsync(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                await _db.InsertAsync(donHang);

                foreach (var ct in danhSachChiTietDb)
                {
                    await _db.InsertAsync(ct);
                }

                foreach (var item in sanPhamList)
                {
                    await _repo.DeductStockAsync(item.MaSp, item.SoLuong);
                }

                await scope.CommitAsync();
            }
            catch
            {
                await scope.RollbackAsync();
                throw;
            }

            return new DonHangDto
            {
                MaDh = donHang.MaDh,
                UserId = donHang.UserId,
                TenNguoiNhan = donHang.TenNguoiNhan,
                SoDt = donHang.SoDt,
                DiaChi = donHang.DiaChi,
                TongTien = donHang.TongTien,
                TrangThai = donHang.TrangThai,
                GhiChu = donHang.GhiChu,
                NgayTao = donHang.NgayTao,
                DanhSachMon = danhSachMonDto
            };
        }
        public async Task<PagedResult<DonHangDto>> GetPagedListAsync(long userId, PagedRequest req, CancellationToken ct = default)
        {
            var skip = (req.PageIndex - 1) * req.PageSize;


            var countRows = await _db.ToListAsync(
                from x in _db.GetAll<DonHangDb>()
                where x.UserId == userId
                select new { total = 1.Count() },
                isMapping: false, ct: ct);

            var total = (long)(countRows.FirstOrDefault()?.total ?? 0);
            var filtered =
            from x in _db.GetAll<DonHangDb>()
            where x.UserId == userId
            select x;
            var numberedQuery =
                from x in filtered
                select new
                {
                    RowNumber = x.RowNumber(() => x.MaDh),
                    x.MaDh,
                    x.UserId,
                    x.TenNguoiNhan,
                    x.SoDt,
                    x.DiaChi,
                    x.TongTien,
                    x.TrangThai,
                    x.GhiChu,
                    x.NgayTao
                };

            var pageQuery =
                from x in numberedQuery
                where x.RowNumber > skip && x.RowNumber <= skip + req.PageSize
                orderby x.RowNumber
                select x;

            var rows = await _db.ToListAsync(pageQuery, isMapping: false, ct: ct);

            return new PagedResult<DonHangDto>(
                rows.Select(x => new DonHangDto
                {
                    MaDh = x.MaDh,
                    UserId = x.UserId,
                    TenNguoiNhan = x.TenNguoiNhan,
                    SoDt = x.SoDt,
                    DiaChi = x.DiaChi,
                    TongTien = x.TongTien,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu,
                    NgayTao = x.NgayTao
                }).ToList(),
                total
            );
        }

        public async Task<PagedResult<DonHangDto>> GetAllOrdersAsync(int? trangThai, PagedRequest req, CancellationToken ct = default)
        {
            var skip = (req.PageIndex - 1) * req.PageSize;

            var baseQuery = from d in _db.GetAll<DonHangDb>() select d;
            if (trangThai.HasValue)
            {
                baseQuery = baseQuery.Where(d => d.TrangThai == trangThai.Value);
            }

            var countRows = await _db.ToListAsync(
                from x in baseQuery
                select new { total = 1.Count() },
                isMapping: false, ct: ct);

            var total = (long)(countRows.FirstOrDefault()?.total ?? 0);

            var numberedQuery =
                from x in baseQuery
                select new
                {
                    RowNumber = x.RowNumber(() => x.MaDh),
                    x.MaDh,
                    x.UserId,
                    x.TenNguoiNhan,
                    x.SoDt,
                    x.DiaChi,
                    x.TongTien,
                    x.TrangThai,
                    x.GhiChu,
                    x.NgayTao
                };

            var pageQuery =
                from x in numberedQuery
                where x.RowNumber > skip && x.RowNumber <= skip + req.PageSize
                orderby x.RowNumber
                select x;

            var rows = await _db.ToListAsync(pageQuery, isMapping: false, ct: ct);

            return new PagedResult<DonHangDto>(
                rows.Select(x => new DonHangDto
                {
                    MaDh = x.MaDh,
                    UserId = x.UserId,
                    TenNguoiNhan = x.TenNguoiNhan,
                    SoDt = x.SoDt,
                    DiaChi = x.DiaChi,
                    TongTien = x.TongTien,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu,
                    NgayTao = x.NgayTao
                }).ToList(),
                total
            );
        }

        public async Task<DonHangDto?> GetOrderByIdAsync(string maDh)
        {
            var order = await _db.FirstOrDefaultAsync<DonHangDto>(
                from d in _db.GetAll<DonHangDb>()
                where d.MaDh == maDh
                select new
                {
                    d.MaDh,
                    d.UserId,
                    d.TenNguoiNhan,
                    d.SoDt,
                    d.DiaChi,
                    d.TongTien,
                    d.TrangThai,
                    d.GhiChu,
                    d.NgayTao
                },
                isMapping: false
            );
            if (order == null) return null;

            order.DanhSachMon = await _db.ToListAsync<ChiTietDonHangDto>(
                from ct in _db.GetAll<ChiTietDonHangDb>()
                from sp in _db.GetAll<SanPhamDb>()
                where ct.MaDh == maDh && ct.MaSp == sp.MaSp
                select new
                {
                    Id = ct.Id,
                    MaSp = ct.MaSp,
                    TenSp = sp.TenSp,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia,
                    ThanhTien = ct.ThanhTien
                },
                isMapping: false
            );

            return order;
        }

        public async Task<bool> UpdateStatusAsync(string maDh, int trangThai)
        {
            var entity = await _db.FirstOrDefaultAsync<DonHangDb>(
                from d in _db.GetAll<DonHangDb>() where d.MaDh == maDh select d
            );
            if (entity == null) return false;

            entity.TrangThai = trangThai;
            await _db.UpdateAsync(entity);
            return true;
        }


    }
}
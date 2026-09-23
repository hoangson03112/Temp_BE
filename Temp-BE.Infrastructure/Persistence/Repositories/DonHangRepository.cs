using NetCore.Oracle.DataAccess;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.DTOs;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Infrastructure.Persistence.Repositories
{

    public class DonHangRepository : IDonHangRepository
    {
        private readonly IDbSession<DbQLBH> _db;
        private readonly ISanPhamRepository _repo;
        public DonHangRepository(IDbSession<DbQLBH> db, ISanPhamRepository repo) { _db = db; _repo = repo; }

        public async Task<DonHangDto> CreateOrderAsync(long userId, CreateDonHangDto dto, List<CreateChiTietDonHangDto> sanPhamList)
        {
            if (sanPhamList == null || !sanPhamList.Any())
            {
                throw new ArgumentException("Danh sách sản phẩm không được để trống.");
            }

            string maDh = $"DH{DateTime.Now:yyMMddHHmmss}{new Random().Next(10, 99)}";
            decimal tongTien = 0;

            var danhSachChiTietDb = new List<ChiTietDonHangDb>();
            var danhSachMonDto = new List<ChiTietDonHangDto>();

            foreach (var item in sanPhamList)
            {
                var product = await _repo.GetByMaSpAsync(item.MaSp);
                if (product == null)
                {
                    throw new Exception($"Sản phẩm với mã '{item.MaSp}' không tồn tại.");
                }

                decimal donGia = product.GiaBan;
                decimal thanhTien = donGia * item.SoLuong;
                tongTien += thanhTien;

                var ctDb = new ChiTietDonHangDb
                {
                    MaDh = maDh,
                    MaSp = item.MaSp,
                    SoLuong = item.SoLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                };
                danhSachChiTietDb.Add(ctDb);

                danhSachMonDto.Add(new ChiTietDonHangDto
                {
                    MaSp = item.MaSp,
                    SoLuong = item.SoLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                });
            }

            var donHang = new DonHangDb
            {
                MaDh = maDh,
                UserId = userId,
                TenNguoiNhan = dto.TenNguoiNhan,
                SoDt = dto.SoDt,
                DiaChi = dto.DiaChi,
                TongTien = tongTien,
                TrangThai = 0,
                GhiChu = dto.GhiChu,
                NgayTao = DateTime.Now
            };

            await _db.InsertAsync(donHang);

            foreach (var ct in danhSachChiTietDb)
            {
                await _db.InsertAsync(ct);
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
        public async Task<List<DonHangDto>> GetOrdersByUserAsync(long userId)
        {
            return await _db.ToListAsync<DonHangDto>(
                from d in _db.GetAll<DonHangDb>()
                where d.UserId == userId
                orderby d.NgayTao descending
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
        }

        public async Task<List<DonHangDto>> GetAllOrdersAsync(int? trangThai)
        {
            var query = from d in _db.GetAll<DonHangDb>() select d;
            if (trangThai.HasValue)
            {
                query = query.Where(d => d.TrangThai == trangThai.Value);
            }

            return await _db.ToListAsync<DonHangDto>(
                from d in query
                orderby d.NgayTao descending
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
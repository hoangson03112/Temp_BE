using NetCore.Oracle.DataAccess;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Infrastructure.Persistence.Repositories
{


    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly IDbSession<DbQLBH> _db;
        public DanhMucRepository(IDbSession<DbQLBH> db) { _db = db; }

        public async Task<PagedResult<DanhMucDto>> GetPagedListAsync(PagedRequest req, CancellationToken ct = default)
        {
            var skip = (req.PageIndex - 1) * req.PageSize;

            var countRows = await _db.ToListAsync(
                from x in _db.GetAll<DanhMucDb>()
                select new { total = 1.Count() },
                isMapping: false, ct: ct);

            var total = (long)(countRows.FirstOrDefault()?.total ?? 0);

            var numberedQuery =
                from x in _db.GetAll<DanhMucDb>()
                select new
                {
                    RowNumber = x.RowNumber(() => x.MaDm),
                    x.MaDm,
                    x.TenDm,
                    x.MoTa,
                    x.TrangThai,

                };

            var pageQuery =
                from x in numberedQuery
                where x.RowNumber > skip && x.RowNumber <= skip + req.PageSize
                orderby x.RowNumber
                select x;

            var rows = await _db.ToListAsync(pageQuery, isMapping: false, ct: ct);

            return new PagedResult<DanhMucDto>(
                rows.Select(x => new DanhMucDto
                {
                    MaDm = x.MaDm,
                    TenDm = x.TenDm,
                    MoTa = x.MoTa,
                    TrangThai = x.TrangThai
                }).ToList(),
                total


            );
        }

        public async Task<DanhMucDto?> GetByIdAsync(string maDm)
        {
            return await _db.FirstOrDefaultAsync<DanhMucDto>(
                from a in _db.GetAll<DanhMucDb>()
                where a.MaDm == maDm
                select new { a.MaDm, a.TenDm, a.MoTa, a.TrangThai },
                isMapping: false
            );
        }

        public async Task<DanhMucDto> CreateAsync(CreateDanhMucRequest req)
        {
            string maDm = $"DM{Guid.NewGuid():N}".Substring(0, 16).ToUpper();
            var entity = new DanhMucDb
            {
                MaDm = maDm,
                TenDm = req.TenDm.Trim(),
                MoTa = req.MoTa,
                TrangThai = 1
            };
            await _db.InsertAsync(entity);
            return new DanhMucDto { MaDm = entity.MaDm, TenDm = entity.TenDm, MoTa = entity.MoTa, TrangThai = entity.TrangThai };
        }

        public async Task<DanhMucDto?> UpdateAsync(string maDm, UpdateDanhMucRequest req)
        {
            var entity = await _db.FirstOrDefaultAsync<DanhMucDb>(
                from a in _db.GetAll<DanhMucDb>() where a.MaDm == maDm select a
            );
            if (entity == null) return null;

            entity.TenDm = req.TenDm;
            entity.MoTa = req.MoTa;
            entity.TrangThai = req.TrangThai;

            await _db.UpdateAsync(entity);
            return new DanhMucDto { MaDm = entity.MaDm, TenDm = entity.TenDm, MoTa = entity.MoTa, TrangThai = entity.TrangThai };
        }

        public async Task<bool> DeleteAsync(string maDm)
        {
            await _db.DeleteWithClauseAsync<DanhMucDb>(x => x.MaDm == maDm);
            return true;
        }

        public async Task<bool> ExistsAsync(string maDm)
        {
            var res = await _db.ToListAsync((from a in _db.GetAll<DanhMucDb>() where a.MaDm == maDm select a.MaDm).Take(1));
            return res.Count > 0;
        }
    }
}
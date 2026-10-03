using NetCore.Oracle.DataAccess;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Infrastructure.Persistence.Repositories
{


    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly IDbSession<DbQLBH> _db;
        public DanhMucRepository(IDbSession<DbQLBH> db) { _db = db; }

        public async Task<List<DanhMucDto>> GetAllAsync()
        {
            return await _db.ToListAsync<DanhMucDto>(
                from a in _db.GetAll<DanhMucDb>()
                select new { a.MaDm, a.TenDm, a.MoTa, a.TrangThai },
                isMapping: false
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
            string maDm = $"DM{DateTime.Now:yyMMddHHmmss}{new Random().Next(10, 99)}";
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
using NetCore.Oracle.DataAccess;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Base.Databases;
using Temp_BE.Domain.DTOs;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Infrastructure.Persistence.Repositories
{
    public class DanhGiaRepository : IDanhGiaRepository
    {
        private readonly IDbSession<DbQLBH> _db;

        public DanhGiaRepository(IDbSession<DbQLBH> db)
        {
            _db = db;
        }

        public async Task<List<DanhGiaDto>> GetByMaSpAsync(string maSp)
        {
            return await _db.ToListAsync<DanhGiaDto>(
                from a in _db.GetAll<DanhGiaSpDb>()
                where a.MaSp == maSp
                select new
                {
                    Id = a.Id,
                    MaSp = a.MaSp,
                    SoSao = a.SoSao,
                    NoiDung = a.NoiDung,
                    NgayTao = a.NgayTao
                },
                isMapping: false
            );
        }

        public async Task<DanhGiaDto> CreateAsync(string maSp, CreateDanhGiaDto dto)
        {
            var entity = new DanhGiaSpDb
            {
                MaSp = maSp,
                SoSao = dto.SoSao,
                NoiDung = dto.NoiDung,
                NgayTao = DateTime.Now
            };

            await _db.InsertAsync(entity);

            return new DanhGiaDto
            {
                Id = entity.Id,
                MaSp = entity.MaSp,
                SoSao = entity.SoSao,
                NoiDung = entity.NoiDung,
                NgayTao = entity.NgayTao
            };
        }
        public async Task<DanhGiaDto?> UpdateAsync(long id, UpdateDanhGiaDto dto)
        {
            var entity = await _db.FirstOrDefaultAsync<DanhGiaSpDb>(
                from a in _db.GetAll<DanhGiaSpDb>()
                where a.Id == id
                select a
            );

            if (entity == null) return null;

            entity.SoSao = dto.SoSao;
            entity.NoiDung = dto.NoiDung;

            await _db.UpdateAsync(entity);

            return new DanhGiaDto
            {
                Id = entity.Id,
                MaSp = entity.MaSp,
                SoSao = entity.SoSao,
                NoiDung = entity.NoiDung,
                NgayTao = entity.NgayTao
            };
        }

        public async Task<bool> DeleteAsync(long id)
        {
            await _db.DeleteWithClauseAsync<DanhGiaSpDb>(x => x.Id == id);
            return true;
        }

        public async Task<bool> ExistsAsync(long id)
        {
            var result = await _db.ToListAsync((from a in _db.GetAll<DanhGiaSpDb>()
                                                where a.Id == id
                                                select a.Id).Take(1));
            return result.Count > 0;
        }
    }
}
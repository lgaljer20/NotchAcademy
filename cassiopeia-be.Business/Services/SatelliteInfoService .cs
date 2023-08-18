using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Data;
using cassiopeia_be.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Business.Services
{
    public class SatelliteInfoService : GenericService<SatelliteInfo>, ISatelliteInfoService
    {
        public SatelliteInfoService(CassiopeiaContext context) : base(context)
        { }

        // Implement GetAllAsync method
        public async Task<IEnumerable<SatelliteInfoDTO>> GetAllAsync()
        {
            var list = await _context.SatelliteInfos.Select(x => new SatelliteInfoDTO
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                LaunchDate = x.LaunchDate,
                Status = x.Status,
                Owner = x.Owner,
                OriginCountry = x.OriginCountry
            }).ToListAsync();

            return list;
        }

        // Implement GetByIdAsync method
        public async Task<SatelliteInfoDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.SatelliteInfos.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return new SatelliteInfoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                LaunchDate = entity.LaunchDate,
                Status = entity.Status,
                Owner = entity.Owner,
                OriginCountry = entity.OriginCountry
            };
        }

        // Implement CreateAsync method
        public async Task<SatelliteInfoDTO?> CreateAsync(CreateEditSatelliteInfoDTO model)
        {
            var entity = new SatelliteInfo
            {
                Name = model.Name,
                Image = model.Image,
                LaunchDate = model.LaunchDate,
                Status = model.Status,
                Owner = model.Owner,
                OriginCountry = model.OriginCountry
            };

            await _context.SatelliteInfos.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new SatelliteInfoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                LaunchDate = entity.LaunchDate,
                Status = entity.Status,
                Owner = entity.Owner,
                OriginCountry = entity.OriginCountry
            };
        }

        // Implement UpdateAsync method
        public async Task<SatelliteInfoDTO?> UpdateAsync(int id, CreateEditSatelliteInfoDTO model)
        {
            var entity = await _context.SatelliteInfos.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            entity.Name = model.Name;
            entity.Image = model.Image;
            entity.LaunchDate = model.LaunchDate;
            entity.Status = model.Status;
            entity.Owner = model.Owner;
            entity.OriginCountry = model.OriginCountry;

            await _context.SaveChangesAsync();

            return new SatelliteInfoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                LaunchDate = entity.LaunchDate,
                Status = entity.Status,
                Owner = entity.Owner,
                OriginCountry = entity.OriginCountry
            };
        }
    }
}

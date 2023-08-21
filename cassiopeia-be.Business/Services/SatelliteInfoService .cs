using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Data;
using cassiopeia_be.Data.Entities;
using cassiopeia_be.Data.Migrations;
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
                StatusIsEnabled = x.StatusIsEnabled,
                Owner = x.Owner,
                OriginCountry = x.OriginCountry,
                ReceivedByIsEnabled = x.ReceivedByIsEnabled,
                SignalCountIsEnabled = x.SignalCountIsEnabled,
                APRSIsEnabled =  x.APRSIsEnabled,
                BatteryVoltageIsEnabled = x.BatteryVoltageIsEnabled,
                BatteryCapacityIsEnabled = x.BatteryCapacityIsEnabled,
                BatteryTemperatureIsEnabled = x.BatteryTemperatureIsEnabled,
                SolarTemperatureIsEnabled = x.SolarTemperatureIsEnabled,
                VHFTemperatureIsEnabled = x.VHFTemperatureIsEnabled,
                OBC9DOTemperatureIsEnabled = x.OBC9DOTemperatureIsEnabled,
                OBCNumberIsEnabled = x.OBCNumberIsEnabled,
                OBCPacketRecordIsEnabled = x.OBCPacketRecordIsEnabled,
                OBCTimestampIsEnabled = x.OBCTimestampIsEnabled,
                OBCMCUTemperatureIsEnabled = x.OBCMCUTemperatureIsEnabled,
                OBCUptimeTotalIsEnabled = x.OBCUptimeTotalIsEnabled,
                OBCRestartIsEnabled = x.OBCRestartIsEnabled,
                OBCFreeMemoryIsEnabled = x.OBCFreeMemoryIsEnabled

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
                StatusIsEnabled = entity.StatusIsEnabled,
                Owner = entity.Owner,
                OriginCountry = entity.OriginCountry,
                ReceivedByIsEnabled = entity.ReceivedByIsEnabled,
                SignalCountIsEnabled = entity.SignalCountIsEnabled,
                APRSIsEnabled = entity.APRSIsEnabled,
                BatteryVoltageIsEnabled = entity.BatteryVoltageIsEnabled,
                BatteryCapacityIsEnabled = entity.BatteryCapacityIsEnabled,
                BatteryTemperatureIsEnabled = entity.BatteryTemperatureIsEnabled,
                SolarTemperatureIsEnabled = entity.SolarTemperatureIsEnabled,
                VHFTemperatureIsEnabled = entity.VHFTemperatureIsEnabled,
                OBC9DOTemperatureIsEnabled = entity.OBC9DOTemperatureIsEnabled,
                OBCNumberIsEnabled = entity.OBCNumberIsEnabled,
                OBCPacketRecordIsEnabled = entity.OBCPacketRecordIsEnabled,
                OBCTimestampIsEnabled = entity.OBCTimestampIsEnabled,
                OBCMCUTemperatureIsEnabled = entity.OBCMCUTemperatureIsEnabled,
                OBCUptimeTotalIsEnabled = entity.OBCUptimeTotalIsEnabled,
                OBCRestartIsEnabled = entity.OBCRestartIsEnabled,
                OBCFreeMemoryIsEnabled = entity.OBCFreeMemoryIsEnabled
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
                StatusIsEnabled = model.StatusIsEnabled,
                Owner = model.Owner,
                OriginCountry = model.OriginCountry,
                ReceivedByIsEnabled = model.ReceivedByIsEnabled,
                SignalCountIsEnabled = model.SignalCountIsEnabled,
                APRSIsEnabled = model.APRSIsEnabled,
                BatteryVoltageIsEnabled = model.BatteryVoltageIsEnabled,
                BatteryCapacityIsEnabled = model.BatteryCapacityIsEnabled,
                BatteryTemperatureIsEnabled = model.BatteryTemperatureIsEnabled,
                SolarTemperatureIsEnabled = model.SolarTemperatureIsEnabled,
                VHFTemperatureIsEnabled = model.VHFTemperatureIsEnabled,
                OBC9DOTemperatureIsEnabled = model.OBC9DOTemperatureIsEnabled,
                OBCNumberIsEnabled = model.OBCNumberIsEnabled,
                OBCPacketRecordIsEnabled = model.OBCPacketRecordIsEnabled,
                OBCTimestampIsEnabled = model.OBCTimestampIsEnabled,
                OBCMCUTemperatureIsEnabled = model.OBCMCUTemperatureIsEnabled,
                OBCUptimeTotalIsEnabled = model.OBCUptimeTotalIsEnabled,
                OBCRestartIsEnabled = model.OBCRestartIsEnabled,
                OBCFreeMemoryIsEnabled = model.OBCFreeMemoryIsEnabled

            };

            await _context.SatelliteInfos.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new SatelliteInfoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                LaunchDate = entity.LaunchDate,
                StatusIsEnabled = entity.StatusIsEnabled,
                Owner = entity.Owner,
                OriginCountry = entity.OriginCountry,
                ReceivedByIsEnabled = entity.ReceivedByIsEnabled,
                SignalCountIsEnabled = entity.SignalCountIsEnabled,
                APRSIsEnabled = entity.APRSIsEnabled,
                BatteryVoltageIsEnabled = entity.BatteryVoltageIsEnabled,
                BatteryCapacityIsEnabled = entity.BatteryCapacityIsEnabled,
                BatteryTemperatureIsEnabled = entity.BatteryTemperatureIsEnabled,
                SolarTemperatureIsEnabled = entity.SolarTemperatureIsEnabled,
                VHFTemperatureIsEnabled = entity.VHFTemperatureIsEnabled,
                OBC9DOTemperatureIsEnabled = entity.OBC9DOTemperatureIsEnabled,
                OBCNumberIsEnabled = entity.OBCNumberIsEnabled,
                OBCPacketRecordIsEnabled = entity.OBCPacketRecordIsEnabled,
                OBCTimestampIsEnabled = entity.OBCTimestampIsEnabled,
                OBCMCUTemperatureIsEnabled = entity.OBCMCUTemperatureIsEnabled,
                OBCUptimeTotalIsEnabled = entity.OBCUptimeTotalIsEnabled,
                OBCRestartIsEnabled = entity.OBCRestartIsEnabled,
                OBCFreeMemoryIsEnabled = entity.OBCFreeMemoryIsEnabled
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
            entity.StatusIsEnabled = model.StatusIsEnabled;
            entity.Owner = model.Owner;
            entity.OriginCountry = model.OriginCountry;
            entity.ReceivedByIsEnabled = model.ReceivedByIsEnabled;
            entity.SignalCountIsEnabled = model.SignalCountIsEnabled;
            entity.APRSIsEnabled = model.APRSIsEnabled;
            entity.BatteryVoltageIsEnabled = model.BatteryVoltageIsEnabled;
            entity.BatteryCapacityIsEnabled = model.BatteryCapacityIsEnabled;
            entity.BatteryTemperatureIsEnabled = model.BatteryTemperatureIsEnabled;
            entity.SolarTemperatureIsEnabled = model.SolarTemperatureIsEnabled;
            entity.VHFTemperatureIsEnabled = model.VHFTemperatureIsEnabled;
            entity.OBC9DOTemperatureIsEnabled = model.OBC9DOTemperatureIsEnabled;
            entity.OBCNumberIsEnabled = model.OBCNumberIsEnabled;
            entity.OBCPacketRecordIsEnabled = model.OBCPacketRecordIsEnabled;
            entity.OBCTimestampIsEnabled = model.OBCTimestampIsEnabled;
            entity.OBCMCUTemperatureIsEnabled = model.OBCMCUTemperatureIsEnabled;
            entity.OBCUptimeTotalIsEnabled = model.OBCUptimeTotalIsEnabled;
            entity.OBCRestartIsEnabled = model.OBCRestartIsEnabled;
            entity.OBCFreeMemoryIsEnabled = model.OBCFreeMemoryIsEnabled;

            await _context.SaveChangesAsync();

            return new SatelliteInfoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                LaunchDate = entity.LaunchDate,
                StatusIsEnabled = entity.StatusIsEnabled,
                Owner = entity.Owner,
                OriginCountry = entity.OriginCountry,
                ReceivedByIsEnabled = entity.ReceivedByIsEnabled,
                SignalCountIsEnabled = entity.SignalCountIsEnabled,
                APRSIsEnabled = entity.APRSIsEnabled,
                BatteryVoltageIsEnabled = entity.BatteryVoltageIsEnabled,
                BatteryCapacityIsEnabled = entity.BatteryCapacityIsEnabled,
                BatteryTemperatureIsEnabled = entity.BatteryTemperatureIsEnabled,
                SolarTemperatureIsEnabled = entity.SolarTemperatureIsEnabled,
                VHFTemperatureIsEnabled = entity.VHFTemperatureIsEnabled,
                OBC9DOTemperatureIsEnabled = entity.OBC9DOTemperatureIsEnabled,
                OBCNumberIsEnabled = entity.OBCNumberIsEnabled,
                OBCPacketRecordIsEnabled = entity.OBCPacketRecordIsEnabled,
                OBCTimestampIsEnabled = entity.OBCTimestampIsEnabled,
                OBCMCUTemperatureIsEnabled = entity.OBCMCUTemperatureIsEnabled,
                OBCUptimeTotalIsEnabled = entity.OBCUptimeTotalIsEnabled,
                OBCRestartIsEnabled = entity.OBCRestartIsEnabled,
                OBCFreeMemoryIsEnabled = entity.OBCFreeMemoryIsEnabled
            };
        }
    }
}

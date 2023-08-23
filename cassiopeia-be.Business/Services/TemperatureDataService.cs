using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Data;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Business.Services
{
    public class TemperatureDataService : ITemperatureDataService
    {
        private readonly CassiopeiaContext _context;

        public TemperatureDataService(CassiopeiaContext context)
        {
            _context = context;
        }

        public async Task<TemperatureDataDTO> GetLatestTemperatureDataAsync(int SatelliteId)
        {
            return await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .OrderByDescending(data => data.Timestamp)
                .Select(data => new TemperatureDataDTO
                {
                    Timestamp = data.Timestamp,
                    BatteryTemperature = data.BatteryTemperature,
                    SystemTemperature = data.SystemTemperature
                })
                .FirstOrDefaultAsync();
        }

        public async Task<double> GetMaxBatteryTemperatureAsync(int SatelliteId)
        {
            return await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.BatteryTemperature);
        }

        public async Task<double> GetMinBatteryTemperatureAsync(int SatelliteId)
        {
            return await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MinAsync(data => data.BatteryTemperature);
        }

        public async Task<double> GetCurrentBatteryTemperatureAsync(int SatelliteId)
        {
            var latestTimestamp = await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.Timestamp);

            var currentBatteryTemperature = await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId && data.Timestamp == latestTimestamp)
                .Select(data => data.BatteryTemperature)
                .FirstOrDefaultAsync();

            return currentBatteryTemperature;
        }

        public async Task<double> GetMaxSystemTemperatureAsync(int SatelliteId)
        {
            return await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.SystemTemperature);
        }

        public async Task<double> GetMinSystemTemperatureAsync(int SatelliteId)
        {
            return await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MinAsync(data => data.SystemTemperature);
        }

        public async Task<double> GetCurrentSystemTemperatureAsync(int SatelliteId)
        {
            var latestTimestamp = await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.Timestamp);

            var currentSystemTemperature = await _context.TemperatureDataRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId && data.Timestamp == latestTimestamp)
                .Select(data => data.SystemTemperature)
                .FirstOrDefaultAsync();

            return currentSystemTemperature;
        }
    }
}

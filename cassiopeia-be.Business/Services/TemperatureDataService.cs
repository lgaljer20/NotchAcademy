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

        public async Task<TemperatureDataDTO> GetLatestTemperatureDataAsync()
        {
            return await _context.TemperatureDataRecords
                .OrderByDescending(data => data.Timestamp)
                .Select(data => new TemperatureDataDTO
                {
                    Timestamp = data.Timestamp,
                    BatteryTemperature = data.BatteryTemperature,
                    SystemTemperature = data.SystemTemperature
                })
                .FirstOrDefaultAsync();
        }

        public async Task<double> GetMaxBatteryTemperatureAsync()
        {
            return await _context.TemperatureDataRecords
                .MaxAsync(data => data.BatteryTemperature);
        }

        public async Task<double> GetMinBatteryTemperatureAsync()
        {
            return await _context.TemperatureDataRecords
                .MinAsync(data => data.BatteryTemperature);
        }

        public async Task<double> GetCurrentBatteryTemperatureAsync()
        {
            var latestTimestamp = await _context.TemperatureDataRecords
                .MaxAsync(data => data.Timestamp);

            var currentBatteryTemperature = await _context.TemperatureDataRecords
                .Where(data => data.Timestamp == latestTimestamp)
                .Select(data => data.BatteryTemperature)
                .FirstOrDefaultAsync();

            return currentBatteryTemperature;
        }

        public async Task<double> GetMaxSystemTemperatureAsync()
        {
            return await _context.TemperatureDataRecords
                .MaxAsync(data => data.SystemTemperature);
        }

        public async Task<double> GetMinSystemTemperatureAsync()
        {
            return await _context.TemperatureDataRecords
                .MinAsync(data => data.SystemTemperature);
        }

        public async Task<double> GetCurrentSystemTemperatureAsync()
        {
            var latestTimestamp = await _context.TemperatureDataRecords
                .MaxAsync(data => data.Timestamp);

            var currentSystemTemperature = await _context.TemperatureDataRecords
                .Where(data => data.Timestamp == latestTimestamp)
                .Select(data => data.SystemTemperature)
                .FirstOrDefaultAsync();

            return currentSystemTemperature;
        }
    }
}

using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Data;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Business.Services
{
    public class BatteryCurrentService : IBatteryCurrentService
    {
        private readonly CassiopeiaContext _context;

        public BatteryCurrentService(CassiopeiaContext context)
        {
            _context = context; 
        }
        public async Task<BatteryCurrentDTO> GetLatestBatteryCurrentAsync(int SatelliteId)
        {
            return await _context.BatteryCurrentRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .OrderByDescending(data => data.Timestamp)
                .Select(data => new BatteryCurrentDTO
                {
                    Timestamp = data.Timestamp,
                    CurrentIn = data.CurrentIn,
                    CurrentOut = data.CurrentOut
                })
                .FirstOrDefaultAsync();
        }

        public async Task<double> GetMaxCurrentInAsync(int SatelliteId)
        {
            return await _context.BatteryCurrentRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.CurrentIn);
        }

        public async Task<double> GetMinCurrentInAsync(int SatelliteId)
        {
            return await _context.BatteryCurrentRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MinAsync(data => data.CurrentIn);
        }

        public async Task<double> GetCurrentCurrentInAsync(int SatelliteId)
        {
            var latestTimestamp = await _context.BatteryCurrentRecords

                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.Timestamp);

            var currentCurrentIn = await _context.BatteryCurrentRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId && data.Timestamp == latestTimestamp)
                .Select(data => data.CurrentIn)
                .FirstOrDefaultAsync();

            return currentCurrentIn;
        }

        public async Task<double> GetMaxCurrentOutAsync(int SatelliteId)
        {
            return await _context.BatteryCurrentRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.CurrentOut);
        }

        public async Task<double> GetMinCurrentOutAsync(int SatelliteId)
        {
            return await _context.BatteryCurrentRecords

                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MinAsync(data => data.CurrentOut);
        }

        public async Task<double> GetCurrentCurrentOutAsync(int SatelliteId)
        {
            var latestTimestamp = await _context.BatteryCurrentRecords

                .Where(data => data.Battery.SatelliteId == SatelliteId)
                .MaxAsync(data => data.Timestamp);

            var currentCurrentOut = await _context.BatteryCurrentRecords
                .Where(data => data.Battery.SatelliteId == SatelliteId && data.Timestamp == latestTimestamp)
                .Select(data => data.CurrentOut)
                .FirstOrDefaultAsync();

            return currentCurrentOut;
        }
    
    }
}

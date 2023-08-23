using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Data;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Business.Services
{
    public class BatteryStatusService : IBatteryStatusService
    {
        private readonly CassiopeiaContext _context;

        public BatteryStatusService(CassiopeiaContext context)
        {
            _context = context;
        }

        public async Task<BatteryStatusDTO> GetBatteryStatusAsync(int SatelliteId)
        {
            var batteryStatus = await _context.BatteryStatuses
                .FirstOrDefaultAsync(bs => bs.Battery.SatelliteId == SatelliteId);

            if (batteryStatus == null)
                return null;

            var batteryStatusDTO = new BatteryStatusDTO
            {
                Voltage = batteryStatus.Voltage,
                Current = batteryStatus.Current,
                ChargeLevel = batteryStatus.ChargeLevel
            };

            return batteryStatusDTO;
        }

    }
}
using cassiopeia_be.Business.DTO;

namespace cassiopeia_be.Business.Interfaces
{
    public interface IBatteryStatusService 
    {
        Task<BatteryStatusDTO> GetBatteryStatusAsync(int SatelliteId);
    }
}


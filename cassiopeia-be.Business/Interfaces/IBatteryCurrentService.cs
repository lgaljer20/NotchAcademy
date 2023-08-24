using cassiopeia_be.Business.DTO;

namespace cassiopeia_be.Business.Interfaces
{
    public interface IBatteryCurrentService
    {
        Task<BatteryCurrentDTO> GetLatestBatteryCurrentAsync(int SatelliteId);
        Task<double> GetMaxCurrentInAsync(int SatelliteId);
        Task<double> GetMinCurrentInAsync(int SatelliteId);
        Task<double> GetCurrentCurrentInAsync(int SatelliteId);
        Task<double> GetMaxCurrentOutAsync(int SatelliteId);
        Task<double> GetMinCurrentOutAsync(int SatelliteId);
        Task<double> GetCurrentCurrentOutAsync(int SatelliteId);
    }
}

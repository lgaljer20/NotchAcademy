using cassiopeia_be.Business.DTO;

namespace cassiopeia_be.Business.Interfaces
{
    public interface ITemperatureDataService
    {
        Task<TemperatureDataDTO> GetLatestTemperatureDataAsync(int SatelliteId);
        Task<double> GetMaxBatteryTemperatureAsync(int SatelliteId);
        Task<double> GetMinBatteryTemperatureAsync(int SatelliteId);
        Task<double> GetCurrentBatteryTemperatureAsync(int SatelliteId);
        Task<double> GetMaxSystemTemperatureAsync(int SatelliteId);
        Task<double> GetMinSystemTemperatureAsync(int SatelliteId);
        Task<double> GetCurrentSystemTemperatureAsync(int SatelliteId);
    }
}

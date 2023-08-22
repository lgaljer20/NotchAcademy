using cassiopeia_be.Business.DTO;

namespace cassiopeia_be.Business.Interfaces
{
    public interface ITemperatureDataService
    {
        Task<TemperatureDataDTO> GetLatestTemperatureDataAsync();
        Task<double> GetMaxBatteryTemperatureAsync();
        Task<double> GetMinBatteryTemperatureAsync();
        Task<double> GetCurrentBatteryTemperatureAsync();
        Task<double> GetMaxSystemTemperatureAsync();
        Task<double> GetMinSystemTemperatureAsync();
        Task<double> GetCurrentSystemTemperatureAsync();
    }
}

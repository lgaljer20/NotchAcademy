using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cassiopeia_be.Business.Interfaces;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureDataController : ControllerBase
    {
        private readonly ITemperatureDataService _temperatureDataService;

        public TemperatureDataController(ITemperatureDataService temperatureDataService)
        {
            _temperatureDataService = temperatureDataService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetTemperatureInfo(int SatelliteId)
        {
            var latestTemperatureData = await _temperatureDataService.GetLatestTemperatureDataAsync(SatelliteId);
            var maxBatteryTemperature = await _temperatureDataService.GetMaxBatteryTemperatureAsync(SatelliteId);
            var minBatteryTemperature = await _temperatureDataService.GetMinBatteryTemperatureAsync(SatelliteId);
            var currentBatteryTemperature = await _temperatureDataService.GetCurrentBatteryTemperatureAsync(SatelliteId);
            var maxSystemTemperature = await _temperatureDataService.GetMaxSystemTemperatureAsync(SatelliteId);
            var minSystemTemperature = await _temperatureDataService.GetMinSystemTemperatureAsync(SatelliteId);
            var currentSystemTemperature = await _temperatureDataService.GetCurrentSystemTemperatureAsync(SatelliteId);

            var temperatureInfo = new
            {
                Timestamp = latestTemperatureData.Timestamp,
                BatteryTemperature = currentBatteryTemperature,
                SystemTemperature = currentSystemTemperature,
                MaxBatteryTemperature = maxBatteryTemperature,
                MinBatteryTemperature = minBatteryTemperature,
                MaxSystemTemperature = maxSystemTemperature,
                MinSystemTemperature = minSystemTemperature
            };

            return Ok(temperatureInfo);
        }
    }
}
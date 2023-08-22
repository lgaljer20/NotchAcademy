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
        public async Task<ActionResult<object>> GetTemperatureInfo()
        {
            var latestTemperatureData = await _temperatureDataService.GetLatestTemperatureDataAsync();
            var maxBatteryTemperature = await _temperatureDataService.GetMaxBatteryTemperatureAsync();
            var minBatteryTemperature = await _temperatureDataService.GetMinBatteryTemperatureAsync();
            var currentBatteryTemperature = await _temperatureDataService.GetCurrentBatteryTemperatureAsync();
            var maxSystemTemperature = await _temperatureDataService.GetMaxSystemTemperatureAsync();
            var minSystemTemperature = await _temperatureDataService.GetMinSystemTemperatureAsync();
            var currentSystemTemperature = await _temperatureDataService.GetCurrentSystemTemperatureAsync();

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
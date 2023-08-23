using cassiopeia_be.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryCurrentController : ControllerBase
    {
        private readonly IBatteryCurrentService _batteryCurrentService;

        public BatteryCurrentController(IBatteryCurrentService batteryCurrentService)
        {
            _batteryCurrentService = batteryCurrentService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetCurrentInfo(int SatelliteId)
        {
            var latestBatteryCurrent = await _batteryCurrentService.GetLatestBatteryCurrentAsync(SatelliteId);
            var maxCurrentIn = await _batteryCurrentService.GetMaxCurrentInAsync(SatelliteId);
            var minCurrentIn = await _batteryCurrentService.GetMinCurrentInAsync(SatelliteId);
            var currentCurrentIn = await _batteryCurrentService.GetCurrentCurrentInAsync(SatelliteId);
            var maxCurrentOut = await _batteryCurrentService.GetMaxCurrentOutAsync(SatelliteId);
            var minCurrentOut= await _batteryCurrentService.GetMinCurrentOutAsync(SatelliteId);
            var currentCurrentOut = await _batteryCurrentService.GetCurrentCurrentOutAsync(SatelliteId);

            var temperatureInfo = new
            {
                Timestamp = latestBatteryCurrent.Timestamp,
                CurrentIn = currentCurrentIn,
                CurrentOut = currentCurrentOut,
                MaxCurrentIn = maxCurrentIn,
                MinCurrentIn = minCurrentIn,
                MaxCurrentOut = maxCurrentOut,
                MinCurrentOut = minCurrentOut
            };

            return Ok(temperatureInfo);
        }
    }
}

using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryStatusController : ControllerBase
    {
        private readonly IBatteryStatusService _batteryStatusService;

        public BatteryStatusController(IBatteryStatusService batteryStatusService)
        {
            _batteryStatusService = batteryStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<BatteryStatusDTO>> GetBatteryStatus(int SatelliteId)
        {
            var batteryStatus = await _batteryStatusService.GetBatteryStatusAsync( SatelliteId);

            if (batteryStatus == null)
                return NotFound();

            return Ok(batteryStatus);
        }
    }
}

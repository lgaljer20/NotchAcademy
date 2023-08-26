using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SatelliteCharacteristicsController : ControllerBase
    {
        private readonly SatelliteCharacteristicsService _service;

        public SatelliteCharacteristicsController(SatelliteCharacteristicsService service)
        {
            _service = service;
        }

  
        [HttpGet]
            public async Task<ActionResult> CheckCollision()
            {
                var (collisionSatellites, goodSatellites) = await _service.CheckForCollision(); 
                var result = new
                {
                    CollisionSatellites = collisionSatellites, //sa kolizijom
                    GoodSatellites = goodSatellites //bez kolizije
                };

                return Ok(result);
            }



        
    }
}

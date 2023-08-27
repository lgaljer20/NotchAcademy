using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ThrusterController : ControllerBase
    {
        private readonly ThrusterService _service;
        public ThrusterController(ThrusterService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThrusterDTO>> GetById(string id)
        {
            var result = await _service.GetThrustersBySatelliteId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateSatellite(float c_x, float c_y, float c_z, float v)
        {
            try
            {
                await _service.UpdateFuelLevel(c_x, c_y, c_z, v);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(new { message = ex.Message });
            }
           

           
        }
    }
}

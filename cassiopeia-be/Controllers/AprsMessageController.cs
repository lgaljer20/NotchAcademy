using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AprsMessageController : ControllerBase
    {
        private readonly AprsMessageService _service;
        public AprsMessageController(AprsMessageService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AprsMessageDTO>> GetById(int id)
        {
            var result = await _service.GetAprsMessagesBySatelliteId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

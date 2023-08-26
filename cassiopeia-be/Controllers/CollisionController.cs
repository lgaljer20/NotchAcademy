using Microsoft.AspNetCore.Mvc;


namespace cassiopeia_be.Controllers
{


    [Route("api/Controller")]
    [ApiController]
    public class CollisionController : ControllerBase
    {
        private readonly ICollisionService _collisionService;

        public CollisionController(ICollisionService collisionService)
        {
            _collisionService = collisionService;
        }

        [HttpGet]
        public async Task<ActionResult<CollisionDTO>> GetCollision(int SatelliteId)
        {
            var collision = await _collisionService.GetCollisionAsync( SatelliteId);

            if (collision == null)
                return NotFound();

            return Ok(collision);
        }
    }
}

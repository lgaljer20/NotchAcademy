using cassiopeia_be.Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatelliteInfoController : ControllerBase
    {
        [HttpGet("GetSatelliteInfo")]
        public IActionResult GetSatelliteInfo()
        {
            var satelliteInfo = new SatelliteInfoDTO
            {
                Name = "cassiopeia",
                Image = "https://some_random_image.jpg",
                LaunchDate = DateTime.Parse("2023-08-07T15:45:00Z"),
                Status = "active",
                Owner = "notch",
                OriginCountry = "Croatia"
            };
            return Ok(satelliteInfo);
        }
    }
}

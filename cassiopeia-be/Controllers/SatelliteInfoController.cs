
﻿using cassiopeia_be.Business.DTO;
using cassiopeia_be.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cassiopeia_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatelliteInfoController : ControllerBase
    {
        private readonly ISatelliteInfoService _service;

        public SatelliteInfoController(ISatelliteInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatelliteInfoDTO>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SatelliteInfoDTO>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SatelliteInfoDTO>> CreateSatellite(CreateEditSatelliteInfoDTO model)
        {
            return Ok(await _service.CreateAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SatelliteInfoDTO>> EditSatellite(int id, CreateEditSatelliteInfoDTO model)
        {
            return Ok(await _service.UpdateAsync(id, model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSatellite(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}


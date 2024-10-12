using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Model;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusculoDeEjercicioController : ControllerBase
    {
        private readonly IMusculoDeEjercicioService _service;

        public MusculoDeEjercicioController(IMusculoDeEjercicioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MusculoDeEjercicio musculoDeEjercicio)
        {
            var createdMusculoDeEjercicio = await _service.CreateAsync(musculoDeEjercicio);
            return CreatedAtAction(nameof(GetById), new { ejercicioId = createdMusculoDeEjercicio.EjercicioId, musculoId = createdMusculoDeEjercicio.MusculoId }, createdMusculoDeEjercicio);
        }

        [HttpGet("{ejercicioId}/{musculoId}")]
        public async Task<IActionResult> GetById(int ejercicioId, int musculoId)
        {
            var musculoDeEjercicio = await _service.GetByIdAsync(ejercicioId, musculoId);
            if (musculoDeEjercicio == null) return NotFound();
            return Ok(musculoDeEjercicio);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var musculosDeEjercicio = await _service.GetAllAsync();
            return Ok(musculosDeEjercicio);
        }

        [HttpPut("{ejercicioId}/{musculoId}")]
        public async Task<IActionResult> Update(int ejercicioId, int musculoId, [FromBody] MusculoDeEjercicio musculoDeEjercicio)
        {
            var updatedMusculoDeEjercicio = await _service.UpdateAsync(ejercicioId, musculoId, musculoDeEjercicio);
            if (updatedMusculoDeEjercicio == null) return NotFound();
            return Ok(updatedMusculoDeEjercicio);
        }

        [HttpDelete("{ejercicioId}/{musculoId}")]
        public async Task<IActionResult> Delete(int ejercicioId, int musculoId)
        {
            var deletedMusculoDeEjercicio = await _service.DeleteAsync(ejercicioId, musculoId);
            if (deletedMusculoDeEjercicio == null) return NotFound();
            return Ok(deletedMusculoDeEjercicio);
        }
    }
}

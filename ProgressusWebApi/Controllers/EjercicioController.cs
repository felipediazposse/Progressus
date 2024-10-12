using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Model;
using ProgressusWebApi.Services;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private readonly IEjercicioService _service;

        public EjercicioController(IEjercicioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ejercicio ejercicio)
        {
            var createdEjercicio = await _service.CreateAsync(ejercicio);
            return CreatedAtAction(nameof(GetById), new { id = createdEjercicio.Id }, createdEjercicio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ejercicio = await _service.GetByIdAsync(id);
            if (ejercicio == null) return NotFound();
            return Ok(ejercicio);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ejercicios = await _service.GetAllAsync();
            return Ok(ejercicios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ejercicio ejercicio)
        {
            var updatedEjercicio = await _service.UpdateAsync(id, ejercicio);
            if (updatedEjercicio == null) return NotFound();
            return Ok(updatedEjercicio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedEjercicio = await _service.DeleteAsync(id);
            if (deletedEjercicio == null) return NotFound();
            return Ok(deletedEjercicio);
        }
    }
}

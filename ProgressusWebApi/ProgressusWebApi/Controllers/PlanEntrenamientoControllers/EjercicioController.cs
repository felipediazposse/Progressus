using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Model;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Controllers.PlanEntrenamientoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private readonly IEjercicioService _ejercicioService;

        public EjercicioController(IEjercicioService ejercicioService)
        {
            _ejercicioService = ejercicioService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Ejercicio ejercicio)
        {
            var ejercicioCreado = await _ejercicioService.Crear(ejercicio);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = ejercicioCreado.Id }, ejercicioCreado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var ejercicio = await _ejercicioService.ObtenerPorId(id);
            if (ejercicio == null) return NotFound();
            return Ok(ejercicio);
        }

        [HttpGet("{grupoMuscularId}")]
        public async Task<IActionResult> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            var ejercicios = await _ejercicioService.ObtenerPorGrupoMuscular(grupoMuscularId);
            if (ejercicios == null) return NotFound();
            return Ok(ejercicios);
        }

        [HttpGet("{musculoId}")]
        public async Task<IActionResult> ObtenerPorMusculo(int grupoMuscularId)
        {
            var ejercicios = await _ejercicioService.ObtenerPorMusculo(grupoMuscularId);
            if (ejercicios == null) return NotFound();
            return Ok(ejercicios);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var ejercicios = await _ejercicioService.ObtenerTodos();
            return Ok(ejercicios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Ejercicio ejercicio)
        {
            var ejercicioActualizado = await _ejercicioService.Actualizar(id, ejercicio);
            if (ejercicioActualizado == null) return NotFound();
            return Ok(ejercicioActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ejercicioEliminado = await _ejercicioService.Eliminar(id);
            if (ejercicioEliminado == null) return NotFound();
            return Ok(ejercicioEliminado);
        }
    }
}

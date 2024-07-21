using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Model;
using ProgressusWebApi.Services.Interfaces;
using ProgressusWebApi.Services.PlanEntrenamientoServices;

namespace ProgressusWebApi.Controllers.PlanEntrenamientoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoMuscularController : ControllerBase
    {
        private readonly IGrupoMuscularService _grupoMuscularService;
        public GrupoMuscularController (IGrupoMuscularService grupoMuscularService)
        {
            _grupoMuscularService = grupoMuscularService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] GrupoMuscular grupoMuscular)
        {
            var grupoMuscularCreado = await _grupoMuscularService.Crear(grupoMuscular);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = grupoMuscularCreado.Id }, grupoMuscularCreado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var grupoMuscular = await _grupoMuscularService.ObtenerPorId(id);
            if (grupoMuscular == null) return NotFound();
            return Ok(grupoMuscular);
        }

        [HttpGet("{nombre}")]
        public async Task<IActionResult> ObtenerPorMusculo(string nombre)
        {
            var gruposMusculares = await _grupoMuscularService.ObtenerPorNombre(nombre);
            if (gruposMusculares == null) return NotFound();
            return Ok(gruposMusculares);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var gruposMusculares = await _grupoMuscularService.ObtenerTodos();
            return Ok(gruposMusculares);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] GrupoMuscular grupoMuscular)
        {
            var grupoMuscularActualizado = await _grupoMuscularService.Actualizar(id, grupoMuscular);
            if (grupoMuscularActualizado == null) return NotFound();
            return Ok(grupoMuscularActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var grupoMuscularEliminado = await _grupoMuscularService.Eliminar(id);
            if (grupoMuscularEliminado == null) return NotFound();
            return Ok(grupoMuscularEliminado);
        }
    }
}

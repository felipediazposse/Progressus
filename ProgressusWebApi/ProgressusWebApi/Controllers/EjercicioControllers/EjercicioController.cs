using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.EjercicioDtos.EjercicioDto;
using ProgressusWebApi.Models.EjercicioModels;
using ProgressusWebApi.Services.EjercicioServices.Interfaces;

namespace ProgressusWebApi.Controllers.EjercicioControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private readonly IEjercicioService _ejercicioService;
        private readonly IMusculoDeEjercicioService _musculoDeEjercicioService;

        public EjercicioController(IEjercicioService ejercicioService, IMusculoDeEjercicioService musculoDeEjercicioService)
        {
            _ejercicioService = ejercicioService;
            _musculoDeEjercicioService = musculoDeEjercicioService;
        }

        [HttpPost("CrearEjercicio")]
        public async Task<IActionResult> Crear([FromBody] CrearActualizarEjercicioDto ejercicio)
        {
            var ejercicioCreado = await _ejercicioService.Crear(ejercicio);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = ejercicioCreado.Id }, ejercicioCreado);
        }

        [HttpGet("ObtenerEjercicioPorId")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var ejercicio = await _ejercicioService.ObtenerPorId(id);
            if (ejercicio == null) return NotFound();
            return Ok(ejercicio);
        }

        [HttpGet("ObtenerEjercicioPorGrupoMuscular")]
        public async Task<IActionResult> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            var ejercicios = await _ejercicioService.ObtenerPorGrupoMuscular(grupoMuscularId);
            if (ejercicios == null) return NotFound();
            return Ok(ejercicios);
        }

        [HttpGet("ObtenerEjercicioPorMusculo")]
        public async Task<IActionResult> ObtenerPorMusculo(int grupoMuscularId)
        {
            var ejercicios = await _ejercicioService.ObtenerPorMusculo(grupoMuscularId);
            if (ejercicios == null) return NotFound();
            return Ok(ejercicios);
        }

        [HttpGet("ObtenerTodosLosEjercicios")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var ejercicios = await _ejercicioService.ObtenerTodos();
            return Ok(ejercicios);
        }

        [HttpPut("ActualizarEjercicio")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] CrearActualizarEjercicioDto ejercicio)
        {
            var ejercicioActualizado = await _ejercicioService.Actualizar(id, ejercicio);
            if (ejercicioActualizado == null) return NotFound();
            return Ok(ejercicioActualizado);
        }

        [HttpDelete("EliminarEjercicio")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ejercicioEliminado = await _ejercicioService.Eliminar(id);
            if (ejercicioEliminado == null) return NotFound();
            return Ok(ejercicioEliminado);
        }

        [HttpPost("AgregarMusculosAEjercicio")]
        public async Task<IActionResult> AgregarMusculosAEjercicio([FromBody]AgregarQuitarMusculoAEjercicioDto agregarQuitarMusculoAEjercicioDto)
        {
            var resultado = _musculoDeEjercicioService.AgregarMusculoAEjercicio(agregarQuitarMusculoAEjercicioDto);
            if (resultado == null) return NotFound();
            return Ok();
        }
    }
}

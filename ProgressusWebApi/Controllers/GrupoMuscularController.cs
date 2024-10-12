using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Data;
using ProgressusWebApi.Dtos.GrupoMuscularDto;
using ProgressusWebApi.Model;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoMuscularController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IGrupoMuscularService _grupoMuscularService;
        public GrupoMuscularController(DataContext context, IMapper mapper, IGrupoMuscularService grupoMuscularService )
        {
            _context = context;
            _mapper = mapper;
            _grupoMuscularService = grupoMuscularService;
        }

        [HttpPost]
            public async Task<IActionResult> Create(CrearGrupoMuscularDto grupoMuscularDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdGrupoMuscular = await _grupoMuscularService.CreateAsync(grupoMuscularDto);
                return CreatedAtAction(nameof(GetById), new { id = createdGrupoMuscular.Id }, createdGrupoMuscular);
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _grupoMuscularService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("exists/{id}")]
        public async Task<IActionResult> Exists(int id)
        {
            var exists = await _grupoMuscularService.ExistsAsync(id);
            return Ok(exists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var grupoMuscular = await _grupoMuscularService.GetByIdAsync(id);
            if (grupoMuscular == null)
                return NotFound();

            return Ok(grupoMuscular);
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> GetByNombre(string nombre)
        {
            var grupoMuscular = await _grupoMuscularService.GetByNombreAsync(nombre);
            if (grupoMuscular == null)
                return NotFound();

            return Ok(grupoMuscular);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grupoMusculares = await _grupoMuscularService.GetAllAsync();


            return Ok(grupoMusculares);
        }


    }
}

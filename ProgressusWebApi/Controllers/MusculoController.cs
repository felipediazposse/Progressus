using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Data;
using ProgressusWebApi.Dtos.MusculoDto;
using ProgressusWebApi.Model;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusculoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMusculoService _musculoService;

        public MusculoController(IMusculoService musculoService, IMapper mapper, DataContext context)
        {
            _musculoService = musculoService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CrearMusculoDto dto)
        {
            if (ModelState.IsValid)
            {
                var musculo = await _musculoService.CreateAsync(dto);
                return Ok(musculo);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var musculo = await _musculoService.DeleteAsync(id);
            if (musculo == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var musculo = await _musculoService.GetByIdAsync(id);
            if (musculo == null)
            {
                return NotFound();
            }

            return Ok(musculo);
        }

        [HttpGet("byname/{nombre}")]
        public async Task<IActionResult> GetByName(string nombre)
        {
            var musculo = await _musculoService.GetByNameAsync(nombre);
            if (musculo == null)
            {
                return NotFound();
            }

            return Ok(musculo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var musculos = await _musculoService.GetAllAsync();
            return Ok(musculos);
        }

        [HttpGet("bygrupomuscular/{grupoMuscularId}")]
        public async Task<IActionResult> GetByGrupoMuscular(int grupoMuscularId)
        {
            var musculos = await _musculoService.GetByGrupoMuscularAsync(grupoMuscularId);
            return Ok(musculos);
        }
    }
}

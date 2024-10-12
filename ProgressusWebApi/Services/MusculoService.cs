using AutoMapper;
using ProgressusWebApi.Dtos.MusculoDto;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services
{
    public class MusculoService : IMusculoService
    {
        private readonly IMusculoRepository _musculoRepository;
        private readonly IMapper _mapper;

        public MusculoService(IMusculoRepository musculoRepository, IMapper mapper)
        {
            _musculoRepository = musculoRepository;
            _mapper = mapper;
        }

        public async Task<Musculo> CreateAsync(CrearMusculoDto musculoDto)
        {
            var musculo = _mapper.Map<Musculo>(musculoDto);
            return await _musculoRepository.CreateAsync(musculo);
        }

        public async Task<Musculo?> DeleteAsync(int id)
        {
            return await _musculoRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _musculoRepository.ExistsAsync(id);
        }

        public async Task<Musculo?> GetByIdAsync(int id)
        {
            return await _musculoRepository.GetByIdAsync(id);
        }

        public async Task<Musculo?> GetByNameAsync(string nombre)
        {
            return await _musculoRepository.GetByNameAsync(nombre);
        }
        public async Task<List<Musculo>> GetAllAsync()
        {
            var musculos = await _musculoRepository.GetAllAsync();
            musculos = QuitarMusculosDelGrupo(musculos);
            return musculos;
        }

        public async Task<List<Musculo>> GetByGrupoMuscularAsync(int grupoMuscularId)
        {
            var musculos = await _musculoRepository.ObtenerPorGrupoMuscular(grupoMuscularId);
            musculos = QuitarMusculosDelGrupo(musculos);
            
            return musculos;
        }

        public List<Musculo> QuitarMusculosDelGrupo(List<Musculo> musculos)
        {
            foreach (Musculo musculo in musculos)
            {
                musculo.GrupoMuscular.MusculosDelGrupo = [];
            }
            return musculos;
        }
    }
}

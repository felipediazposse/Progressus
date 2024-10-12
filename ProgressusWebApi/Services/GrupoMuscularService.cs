using AutoMapper;
using ProgressusWebApi.Dtos.GrupoMuscularDto;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services
{
    public class GrupoMuscularService : IGrupoMuscularService
    {
        private readonly IGrupoMuscularRepository _grupoMuscularRepository;
        private readonly IMapper _mapper;

        public GrupoMuscularService(IGrupoMuscularRepository grupoMuscularRepository, IMapper mapper)
        {
            _grupoMuscularRepository = grupoMuscularRepository;
            _mapper = mapper;
        }

        public async Task<GrupoMuscular> CreateAsync(CrearGrupoMuscularDto grupoMuscularDto)
        {
            var grupoMuscular = _mapper.Map<GrupoMuscular>(grupoMuscularDto);
            return await _grupoMuscularRepository.CreateAsync(grupoMuscular);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _grupoMuscularRepository.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _grupoMuscularRepository.ExistsAsync(id);
        }

        public Task<GrupoMuscular> GetByIdAsync(int id)
        {
            return _grupoMuscularRepository.GetByIdAsync(id);
        }

        public Task<GrupoMuscular> GetByNombreAsync(string nombre)
        {
            return _grupoMuscularRepository.GetByNombreAsync(nombre);
        }

        public Task<List<GrupoMuscular>> GetAllAsync()
        {
            return _grupoMuscularRepository.GetAllAsync();
        }
    }
}

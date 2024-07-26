using ProgressusWebApi.Models.EjercicioModels;
using ProgressusWebApi.Repositories.EjercicioRepositories.Interfaces;
using ProgressusWebApi.Services.EjercicioServices.Interfaces;

namespace ProgressusWebApi.Services.EjercicioServices
{
    public class MusculoService : IMusculoService
    {
        public readonly IMusculoRepository _musculoRepository;
        public MusculoService(IMusculoRepository musculoRepository)
        {
            _musculoRepository = musculoRepository;
        }

        public async Task<Musculo> Crear(Musculo musculo)
        {
            return await _musculoRepository.Crear(musculo);
        }

        public async Task<Musculo?> Eliminar(int id)
        {
            return await _musculoRepository.Eliminar(id);
        }

        public async Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            return await _musculoRepository.ObtenerPorGrupoMuscular(grupoMuscularId);
        }

        public async Task<Musculo?> ObtenerPorId(int id)
        {
            return await _musculoRepository.ObtenerPorId(id);
        }

        public async Task<Musculo?> ObtenerPorNombre(string nombre)
        {
            return await _musculoRepository.ObtenerPorNombre(nombre);
        }

        public async Task<List<Musculo>> ObtenerTodos()
        {
            return await _musculoRepository.ObtenerTodos();
        }
    }
}

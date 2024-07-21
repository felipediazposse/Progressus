using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices
{
    public class MusculoService : IMusculoService
    {
        public readonly IMusculoRepository _musculoRepository;
        public MusculoService(IMusculoRepository musculoRepository)
        {
            _musculoRepository = musculoRepository;
        }
        public Task<bool> ComprobarExistencia(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Musculo> Crear(Musculo musculo)
        {
            return await _musculoRepository.Crear(musculo);
        }

        public Task<Musculo?> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            throw new NotImplementedException();
        }

        public Task<Musculo?> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Musculo?> ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<List<Musculo>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

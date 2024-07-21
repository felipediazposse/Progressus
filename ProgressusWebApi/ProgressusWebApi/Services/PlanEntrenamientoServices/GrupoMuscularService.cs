using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices
{
    public class GrupoMuscularService : IGrupoMuscularService
    {
        private readonly IGrupoMuscularRepository _grupoMuscularRepository;
        public GrupoMuscularService (IGrupoMuscularRepository grupoMuscularRepository)
        {
            _grupoMuscularRepository = grupoMuscularRepository;
        }
        public async Task<GrupoMuscular> Crear(GrupoMuscular grupoMuscular)
        {
            return await _grupoMuscularRepository.Crear(grupoMuscular);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _grupoMuscularRepository.Eliminar(id);
        }

        public async Task<GrupoMuscular> ObtenerPorId(int id)
        {
            return await _grupoMuscularRepository.ObtenerPorId(id);
        }

        public async Task<List<GrupoMuscular>> ObtenerPorNombre(string nombre)
        {
            return await _grupoMuscularRepository.ObtenerPorNombre(nombre);
        }

        public async Task<GrupoMuscular> Actualizar(int id, GrupoMuscular grupoMuscular)
        {
            return await _grupoMuscularRepository.Actualizar(id, grupoMuscular);
        }
        public async Task<List<GrupoMuscular>> ObtenerTodos()
        {
            return await _grupoMuscularRepository.ObtenerTodos();
        }
    }
}

using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices
{
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repository;
        public EjercicioService(IEjercicioRepository repository)
        {
            _repository = repository;
        } 
        public async Task<Ejercicio?> Actualizar(int id, Ejercicio ejercicio)
        {
            return await _repository.Actualizar(id, ejercicio);
        }

        public async Task<Ejercicio> Crear(Ejercicio ejercicio)
        {
            return await _repository.Crear(ejercicio);
        }

        public async Task<Ejercicio?> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<List<Ejercicio?>> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            return await _repository.ObtenerPorGrupoMuscular(grupoMuscularId);    
        }

        public async Task<Ejercicio?> ObtenerPorId(int id)
        {
            return await _repository.ObtenerPorId(id);
        }

        public async Task<List<Ejercicio?>> ObtenerPorMusculo(int musculoId)
        {
            return await _repository.ObtenerPorMusculo(musculoId);
        }

        public async Task<List<Ejercicio?>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }
    }
}

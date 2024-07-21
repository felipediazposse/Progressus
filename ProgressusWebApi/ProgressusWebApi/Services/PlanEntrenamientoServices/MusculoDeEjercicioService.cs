using ProgressusWebApi.Model;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices
{
    public class MusculoDeEjercicioService : IMusculoDeEjercicioService
    {
        public Task<MusculoDeEjercicio?> Actualizar(int ejercicioId, int musculoId, MusculoDeEjercicio musculoDeEjercicio)
        {
            throw new NotImplementedException();
        }

        public Task<MusculoDeEjercicio> Crear(MusculoDeEjercicio musculoDeEjercicio)
        {
            throw new NotImplementedException();
        }

        public Task<MusculoDeEjercicio?> Eliminar(int ejercicioId, int musculoId)
        {
            throw new NotImplementedException();
        }

        public Task<MusculoDeEjercicio?> ObtenerPorId(int ejercicioId, int musculoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MusculoDeEjercicio>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

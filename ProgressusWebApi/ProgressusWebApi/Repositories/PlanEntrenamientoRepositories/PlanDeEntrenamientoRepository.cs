using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
{
    public class PlanDeEntrenamientoRepository : IPlanDeEntrenamientoRepository
    {
        public Task<PlanDeEntrenamiento?> Actualizar(int id, PlanDeEntrenamiento planDeEntrenamiento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ComprobarExistencia(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlanDeEntrenamiento> Crear(PlanDeEntrenamiento planDeEntrenamiento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlanDeEntrenamiento> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlanDeEntrenamiento> ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlanDeEntrenamiento>> ObtenerPorObjetivoDePlan(int objetivoDePlanId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlanDeEntrenamiento>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

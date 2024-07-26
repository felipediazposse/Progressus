using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
{
    public class ObjetivoDelPlanRepository : IObjetivoDelPlanRepository
    {
        public Task<ObjetivoDelPlan> Crear(ObjetivoDelPlan objetivoDelPlan)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ObjetivoDelPlan>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

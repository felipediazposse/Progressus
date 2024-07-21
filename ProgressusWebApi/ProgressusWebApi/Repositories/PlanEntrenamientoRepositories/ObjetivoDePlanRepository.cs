using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
{
    public class ObjetivoDePlanRepository : IObjetivoDePlanRepository
    {
        public Task<ObjetivoDelPlan?> Actualizar(int id, ObjetivoDelPlan objetivoDelPlan)
        {
            throw new NotImplementedException();
        }

        public Task<ObjetivoDelPlan> Crear(ObjetivoDelPlan objetivoDelPlan)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ObjetivoDelPlan> ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<List<ObjetivoDelPlan>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

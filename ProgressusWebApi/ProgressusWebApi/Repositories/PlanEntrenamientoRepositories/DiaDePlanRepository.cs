using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
{
    public class DiaDePlanRepository : IDiaDePlanRepository
    {
        public Task<DiaDePlan> Crear(int planDeEntrenamientoId, int numeroDeDia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int planDeEntrenamientoId, int numeroDeDia)
        {
            throw new NotImplementedException();
        }
    }
}

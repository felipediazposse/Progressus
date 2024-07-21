using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces
{
    public interface IDiaDePlanRepository
    {
        Task<DiaDePlan> Crear(DiaDePlan diaDePlan);
        Task<bool> Eliminar(int id);
    }
}

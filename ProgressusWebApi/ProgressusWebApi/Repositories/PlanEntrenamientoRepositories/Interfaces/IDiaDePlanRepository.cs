using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces
{
    public interface IDiaDePlanRepository
    {
        Task<DiaDePlan> Crear(int planDeEntrenamientoId, int numeroDeDia);
        Task<bool> Eliminar(int planDeEntrenamientoId, int numeroDeDia);
    }
}

using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces
{
    public interface IObjetivoDelPlanRepository
    {
        Task<ObjetivoDelPlan> Crear(ObjetivoDelPlan objetivoDelPlan);
        Task<bool> Eliminar(int id);
        Task<List<ObjetivoDelPlan>> ObtenerTodos();
    }
}

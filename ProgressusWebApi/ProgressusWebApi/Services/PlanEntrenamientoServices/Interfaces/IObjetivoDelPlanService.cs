using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices.Interfaces
{
    public interface IObjetivoDelPlanService
    {
        Task<ObjetivoDelPlan> Crear(ObjetivoDelPlan objetivoDelPlan);
        Task<bool> Eliminar(int id);
        Task<List<ObjetivoDelPlan>> ObtenerTodos();
    }
}

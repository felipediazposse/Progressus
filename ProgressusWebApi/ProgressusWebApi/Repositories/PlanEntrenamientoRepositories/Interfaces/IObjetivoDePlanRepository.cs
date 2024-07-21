using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces
{
    public interface IObjetivoDePlanRepository
    {
        Task<ObjetivoDelPlan> Crear(ObjetivoDelPlan objetivoDelPlan);
        Task<bool> Eliminar(int id);
        Task<ObjetivoDelPlan> ObtenerPorNombre(string nombre);
        Task<List<ObjetivoDelPlan>> ObtenerTodos();
        Task<ObjetivoDelPlan?> Actualizar(int id, ObjetivoDelPlan objetivoDelPlan);
    }
}

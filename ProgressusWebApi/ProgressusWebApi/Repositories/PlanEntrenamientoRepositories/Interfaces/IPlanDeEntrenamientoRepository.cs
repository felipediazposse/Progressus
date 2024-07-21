using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IPlanDeEntrenamientoRepository
    {
        Task<PlanDeEntrenamiento> Crear(PlanDeEntrenamiento planDeEntrenamiento);
        Task<bool> Eliminar(int id);
        Task<bool> ComprobarExistencia(int id);
        Task<PlanDeEntrenamiento> ObtenerPorId(int id);
        Task<PlanDeEntrenamiento> ObtenerPorNombre(string nombre);
        Task<List<PlanDeEntrenamiento>> ObtenerTodos();
        Task<PlanDeEntrenamiento?> Actualizar(int id, PlanDeEntrenamiento planDeEntrenamiento);
        Task<List<PlanDeEntrenamiento>> ObtenerPorObjetivoDePlan(int objetivoDePlanId);
    }
}

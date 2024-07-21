using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices.Interfaces
{
    public interface IPlanDeEntrenamientoService
    {
        Task<PlanDeEntrenamiento> Crear(PlanDeEntrenamiento plan);
        Task<PlanDeEntrenamiento> ObtenerPlanAsginado(int socioId);
        Task<PlanDeEntrenamiento> Actualizar(int id, PlanDeEntrenamiento planActualizado);
        Task<PlanDeEntrenamiento> Eliminar(int id);
        Task<List<PlanDeEntrenamiento>> ObtenerPlantillasDePlanes();
        Task<List<PlanDeEntrenamiento>> ObtenerHistorialDePlanesAsignados(int socioId);
        Task<PlanDeEntrenamiento> AgregarEjercicio(int planEntrenamientoId, int ejercicioId, int diaDeLaSemana);
        Task<PlanDeEntrenamiento> QuitarEjercicio(int planEntrenamientoId, int ejercicioId, int diaDeLaSemana);
    }
}

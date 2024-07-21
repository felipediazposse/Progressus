using ProgressusWebApi.Model;
using ProgressusWebApi.Models.PlanEntrenamientoModels;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces
{
    public interface IEjercicioEnDiaDelPlanRepository
    {
        Task<List<EjercicioEnDiaDelPlan>> ObtenerEjerciciosDelDia(int diaDelPlanId);
        Task<EjercicioEnDiaDelPlan?> AgregarEjercicioADiaDelPlan(int diaDelPlanId, int ejercicioId);
        Task<EjercicioEnDiaDelPlan?> QuitarEjercicioDelDiaDelPlan(int diaDelPlanId, int ejercicioId);
    }
}

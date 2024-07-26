using ProgressusWebApi.Models.PlanEntrenamientoModels;
using ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
{
    public class EjercicioEnDiaDelPlanRepository : IEjercicioEnDiaDelPlanRepository
    {
        public Task<EjercicioEnDiaDelPlan?> AgregarEjercicioADiaDelPlan(int diaDelPlanId, int ejercicioId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EjercicioEnDiaDelPlan>> ObtenerEjerciciosDelDia(int diaDelPlanId)
        {
            throw new NotImplementedException();
        }

        public Task<EjercicioEnDiaDelPlan?> QuitarEjercicioDelDiaDelPlan(int diaDelPlanId, int ejercicioId)
        {
            throw new NotImplementedException();
        }
    }
}

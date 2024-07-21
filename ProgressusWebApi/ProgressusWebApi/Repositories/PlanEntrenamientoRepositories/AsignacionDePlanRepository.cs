using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Model;
using ProgressusWebApi.Models.PlanEntrenamientoModels;
using ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
{
    public class AsignacionDePlanRepository : IAsignacionDePlanRepository
    {
        private readonly ProgressusDataContext _context;

        public AsignacionDePlanRepository(ProgressusDataContext context)
        {
            _context = context;
        }

        public Task<AsignacionDePlan?> AsignarPlan(string socioId, int planEntrenamientoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AsignacionDePlan>> ObtenerHistorialDePlanesAsignados(string socioId)
        {
            throw new NotImplementedException();
        }

        public Task<AsignacionDePlan> ObtenerPlanAsignado(string socioId)
        {
            throw new NotImplementedException();
        }

        public Task<AsignacionDePlan?> QuitarAsignacionDePlan(string socioId, int planDeEntrenamientoId)
        {
            throw new NotImplementedException();
        }
    }
}

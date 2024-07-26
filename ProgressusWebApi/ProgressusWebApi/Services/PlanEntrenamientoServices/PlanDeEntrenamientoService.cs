using ProgressusWebApi.Dtos.EjercicioDtos.EjercicioDto;
using ProgressusWebApi.Model;
using ProgressusWebApi.Models.EjercicioModels;
using ProgressusWebApi.Repositories.EjercicioRepositories.Interfaces;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Repositories.PlanEntrenamientoRepositories.Interfaces;
using ProgressusWebApi.Services.PlanEntrenamientoServices.Interfaces;

namespace ProgressusWebApi.Services.PlanEntrenamientoServices
{
    public class PlanDeEntrenamientoService : IPlanDeEntrenamientoService
    {
        private readonly IPlanDeEntrenamientoRepository _planEntrenamientoRepository;
        private readonly IDiaDePlanRepository _diaDePlanRepository;
        private readonly IEjercicioEnDiaDelPlanRepository _ejercicioDePlanRepository;
        private readonly IEjercicioRepository _ejercicioRepository;
        public PlanDeEntrenamientoService(IPlanDeEntrenamientoRepository planEntrenamientoRepository, IDiaDePlanRepository diaDePlanRepository, IEjercicioEnDiaDelPlanRepository ejercicioDePlanRepository, IEjercicioRepository ejercicioRepository)
        {
            _planEntrenamientoRepository = planEntrenamientoRepository;
            _diaDePlanRepository = diaDePlanRepository;
            _ejercicioDePlanRepository = ejercicioDePlanRepository;
            _ejercicioRepository = ejercicioRepository;
        }
        public Task<PlanDeEntrenamiento> Crear(PlanDeEntrenamiento plan)
        {
            var planCreado = _planEntrenamientoRepository.Crear(plan);
            for (int i = 0; i < plan.DiasPorSemana; i++)
            {
                _diaDePlanRepository.Crear(plan.Id, i);
            }
            return planCreado;
        }
        public async Task<PlanDeEntrenamiento> Actualizar(int id, PlanDeEntrenamiento planActualizado)
        {
            PlanDeEntrenamiento planSinActualizar = _planEntrenamientoRepository.ObtenerPorId(id).Result;
            if (planSinActualizar.DiasPorSemana > planActualizado.DiasPorSemana)
            {
                int diasAQuitar = planSinActualizar.DiasPorSemana - planActualizado.DiasPorSemana;
                for (int i = 0; i < diasAQuitar; i++)
                {
                    _diaDePlanRepository.Eliminar(id, planSinActualizar.DiasPorSemana - i);
                }
            }
            if (planSinActualizar.DiasPorSemana < planActualizado.DiasPorSemana)
            {
                int diasAAgregar = planActualizado.DiasPorSemana - planSinActualizar.DiasPorSemana;
                for (int i = 0; i < diasAAgregar; i--)
                {
                    _diaDePlanRepository.Crear(id, planSinActualizar.DiasPorSemana + 1 + i);
                }
            }
            return await _planEntrenamientoRepository.Actualizar(id, planActualizado);
        }

        public Task<PlanDeEntrenamiento> AgregarEjercicio(AgregarQuitarMusculoAEjercicioDto ejercicio)
        {
            throw new NotImplementedException();
        }
        public Task<PlanDeEntrenamiento> QuitarEjercicio(AgregarQuitarMusculoAEjercicioDto ejercicio)
        {
            throw new NotImplementedException();
        }

        public Task<PlanDeEntrenamiento> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlanDeEntrenamiento>> ObtenerHistorialDePlanesAsignados(int socioId)
        {
            throw new NotImplementedException();
        }

        public Task<PlanDeEntrenamiento> ObtenerPlanAsginado(int socioId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlanDeEntrenamiento>> ObtenerPlantillasDePlanes()
        {
            throw new NotImplementedException();
        }
    }
}

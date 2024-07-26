using ProgressusWebApi.Model;

namespace ProgressusWebApi.Dtos.PlanDeEntrenamientoDtos
{
    public class AgregarQuitarEjerciciosAPlanDto
    {
        public int PlanDeEntrenamientoId { get; set; }
        public List<EjerciciosOrdenadosEnPlanDto> Ejercicios { get; set; }
    }
}

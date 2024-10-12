namespace ProgressusWebApi.Model
{
    public class DiaDePlan
    {
        public int Id { get; set; }
        public int PlanDeEntrenamientoId { get; set; }
        public PlanDeEntrenamiento PlanDeEntrenamiento { get; set; }
        public int NumeroDeDia { get; set; }
        public int NumeroDeSemana { get; set; }
        public List<EjercicioDelDia> EjerciciosDelDia { get; set; } = new List<EjercicioDelDia>();
    }
}

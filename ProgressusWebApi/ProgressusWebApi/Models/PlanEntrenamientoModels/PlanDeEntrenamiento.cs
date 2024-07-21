namespace ProgressusWebApi.Model
{
    public class PlanDeEntrenamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ObjetivoDelPlanId { get; set; }
        public ObjetivoDelPlan ObjetivoDelPlan { get; set; }
        public int DiasPorSemana { get; set; }
        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;
        public int CantidadDeSemanas { get; set; }
        public bool EsPlantilla {  get; set; }
        public List<DiaDePlan> DiasDelPlan { get; set; } = new List<DiaDePlan>();
    }
}

namespace ProgressusWebApi.Model
{
    public class EjercicioDelDia
    {
        public int Id { get; set; }
        public int DiaDePlanId { get; set; }
        public DiaDePlan DiaDePlan { get; set; }
        public int EjercicioId { get; set; }
        public Ejercicio Ejercicio { get; set; }
        public int OrdenDeEjercicio { get; set; }
        public List<SerieDeEjercicio> SeriesDeEjercicio { get; set; } = new List<SerieDeEjercicio>();
    }
}

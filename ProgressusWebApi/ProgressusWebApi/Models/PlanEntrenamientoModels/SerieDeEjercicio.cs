namespace ProgressusWebApi.Model
{
    public class SerieDeEjercicio
    {
        public int Id { get; set; }
        public int EjercicioDelDiaId { get; set; }
        public EjercicioEnDiaDelPlan EjercicioDelDia { get; set; }
        public int NumeroDeSerie { get; set; }
        public int RepeticionesConcretadas { get; set; }
        public DateTime fechaDeRealizacion { get; set; }
    }
}

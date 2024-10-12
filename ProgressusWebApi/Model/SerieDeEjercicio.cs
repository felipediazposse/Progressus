namespace ProgressusWebApi.Model
{
    public class SerieDeEjercicio
    {
        public int Id { get; set; }
        public int EjercicioDelDiaId { get; set; }
        public EjercicioDelDia EjercicioDelDia { get; set; }
        public int NumeroDeSerie { get; set; }
        public int Repeticiones { get; set; }
        public int RepeticionesConcretadas { get; set; }
    }
}

namespace ProgressusWebApi.Model
{
    public class MusculoDeEjercicio
    {
        public int EjercicioId { get; set; }
        public Ejercicio Ejercicio { get; set; }
        public int MusculoId { get; set; }
        public Musculo Musculo { get; set; }
    }
}

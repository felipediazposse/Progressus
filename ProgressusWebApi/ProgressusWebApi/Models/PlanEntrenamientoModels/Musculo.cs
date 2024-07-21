namespace ProgressusWebApi.Model
{
    public class Musculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int GrupoMuscularId { get; set; }
        public GrupoMuscular GrupoMuscular { get; set; }
        public string? ImagenMusculo { get; set; }
        public List<MusculoDeEjercicio> MusculosDeEjercicio { get; set; } = new List<MusculoDeEjercicio>();
    }
}

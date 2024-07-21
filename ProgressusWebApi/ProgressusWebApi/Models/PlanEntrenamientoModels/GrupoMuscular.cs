namespace ProgressusWebApi.Model
{
    public class GrupoMuscular
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string? ImagenGrupoMuscular { get; set; }

        public List<Musculo>? MusculosDelGrupo { get; set; } = new List<Musculo>();
    }
}

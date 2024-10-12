namespace ProgressusWebApi.Dtos.GrupoMuscularDto
{
    public class CrearGrupoMuscularDto
    {
        public required string nombre { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public string? ImagenGrupoMuscular { get; set; }  // Puede ser nulo
    }
}

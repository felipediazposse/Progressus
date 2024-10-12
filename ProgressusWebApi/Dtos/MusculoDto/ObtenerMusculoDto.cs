using ProgressusWebApi.Dtos.GrupoMuscularDto;

namespace ProgressusWebApi.Dtos.MusculoDto
{
    public class ObtenerMusculoDto
    {
        public class MusculoDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int GrupoMuscularId { get; set; }
            public GrupoMuscularVacioDto GrupoMuscular { get; set; }
            public string ImagenMusculo { get; set; }
        }

    }
}

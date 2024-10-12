using System.ComponentModel.DataAnnotations;

namespace ProgressusWebApi.Dtos.MusculoDto
{
    public class CrearMusculoDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "El nombre debe tener por lo menos 4 caracteres")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        public string? ImagenMusculo { get; set; }
    }
}

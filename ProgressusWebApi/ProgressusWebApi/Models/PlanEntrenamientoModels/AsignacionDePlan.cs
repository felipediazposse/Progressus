using Microsoft.AspNetCore.Identity;
using ProgressusWebApi.Model;

namespace ProgressusWebApi.Models.PlanEntrenamientoModels
{
    public class AsignacionDePlan
    {
        public string SocioId { get; set; }
        public IdentityUser Socio { get; set; }
        public PlanDeEntrenamiento PlanDeEntrenamiento { get; set; }
        public int PlanDeEntrenamientoId { get; set; }
        public DateTime fechaDeAsginacion { get; set; }
        public bool esVigente { get; set; }
    }
}

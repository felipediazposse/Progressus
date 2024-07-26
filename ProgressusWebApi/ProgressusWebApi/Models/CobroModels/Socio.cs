using MercadoPago.Resource.Common;
using MercadoPago.Resource.Preference;
using Microsoft.AspNetCore.Identity;

namespace WebApiMercadoPago.Models
{
    public class Socio
    {
        public IdentityUser usuario { get; set; }
        public int usuarioId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public Telefono Telefono { get; set; }

        public Identificacion Identificacion { get; set; }

    }
}

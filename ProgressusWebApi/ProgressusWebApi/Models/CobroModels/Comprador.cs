using MercadoPago.Resource.Common;
using MercadoPago.Resource.Preference;

namespace WebApiMercadoPago.Models
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public Telefono Telefono { get; set; }

        public Identificacion Identificacion { get; set; }
        public Domicilio Domicilio { get; set; }

    }
}

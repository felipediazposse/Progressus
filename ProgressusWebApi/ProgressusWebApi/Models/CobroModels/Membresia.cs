namespace WebApiMercadoPago.Models
{
    public class Membresia
    {
        public int Id { get; set; }
        public int SolicitudDePagoId { get; set; }
        public SolicitudDePago SolicitudDePago { get; set; }

        public DateTime InicioMembresia { get; set; }
        public DateTime FinDeMembresia { get; set; }
    }
}

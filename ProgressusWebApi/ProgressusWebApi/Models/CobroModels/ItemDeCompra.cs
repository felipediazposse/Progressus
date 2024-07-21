namespace WebApiMercadoPago.Models
{
    public class ItemDeCompra
    {
        public int Id { get; set; }
        public int SolicitudDePagoId { get; set; }

        public SolicitudDePago SolicitudDePago { get; set; }
    }
}

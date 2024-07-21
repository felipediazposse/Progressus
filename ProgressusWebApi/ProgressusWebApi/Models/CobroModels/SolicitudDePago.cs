namespace WebApiMercadoPago.Models
{
    public class SolicitudDePago
    {
        public int Id { get; set; }
        public Comprador? Comprador { get; set; }
        public int CompradorId { get; set; }
        public EstadoSolicitudDePago? EstadoSolicitudDePago { get; set; }
        public int EstadoSolicitudDePagoId { get; set; }
        public List<ItemDeCompra>? ItemsDeCompra { get; set; }
    }
}

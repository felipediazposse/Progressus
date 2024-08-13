namespace WebApiMercadoPago.Models
{
    public class SolicitudDePago
    {
        public int Id { get; set; }
        public Socio? Comprador { get; set; }
        public int CompradorId { get; set; }
        public EstadoSolicitudDePago? EstadoSolicitudDePago { get; set; }
        public int EstadoSolicitudDePagoId { get; set; }
        public Membresia TipoMembresia { get; set; }
        public int TipoMembresiaId { get; set; }
        public List<EstadoSolicitudDePago> HistorialEstadoSolicitudDePago { get; set; }
    }
}

namespace EstadisticasIndependiente.Domain.Entities
{
    public partial class Pronostico : BaseAuditableEntity
    {
        public int PartidoId { get; set; }
        public ResultadoPronostico Resultado { get; set; }
    }
}

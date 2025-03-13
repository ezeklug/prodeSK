namespace EstadisticasIndependiente.Domain.Entities
{
    public partial class Equipo : BaseAuditableEntity
    {
        public required string Nombre { get; set; }

        public DateTime? FechaFundacion { get; set; }
    }
}

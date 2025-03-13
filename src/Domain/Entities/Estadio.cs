namespace EstadisticasIndependiente.Domain.Entities
{
    public partial class Estadio : BaseAuditableEntity
    {
        public required string Nombre { get; set; }

        public DateTime? FechaInauguracion { get; set; }
        public required virtual Equipo Equipo { get; set; }
    }
}

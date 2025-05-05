namespace EstadisticasIndependiente.Domain.Entities
{
    public partial class Partido : BaseAuditableEntity
    {
        public required string EquipoLocal { get; set; }
        public required string EquipoVisitante { get; set; }
        public required int Iteracion { get; set; }
    }
}

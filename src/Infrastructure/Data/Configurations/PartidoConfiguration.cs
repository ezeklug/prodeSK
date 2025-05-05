using EstadisticasIndependiente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EstadisticasIndependiente.Infrastructure.Data.Configurations
{
    public class PartidoConfiguration : IEntityTypeConfiguration<Partido>
    {
        public void Configure(EntityTypeBuilder<Partido> builder)
        {
            builder.Property(t => t.EquipoLocal)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.EquipoVisitante)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Iteracion)
                .IsRequired();
        }
    }

}

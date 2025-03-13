using EstadisticasIndependiente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EstadisticasIndependiente.Infrastructure.Data.Configurations
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.Property(t => t.Nombre)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.FechaFundacion);
        }
    }

}

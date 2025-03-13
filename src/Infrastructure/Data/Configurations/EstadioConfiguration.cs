using EstadisticasIndependiente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EstadisticasIndependiente.Infrastructure.Data.Configurations
{
    public class EstadioConfiguration : IEntityTypeConfiguration<Estadio>
    {
        public void Configure(EntityTypeBuilder<Estadio> builder)
        {
            builder.Property(t => t.Nombre)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.FechaInauguracion);
        }
    }
}

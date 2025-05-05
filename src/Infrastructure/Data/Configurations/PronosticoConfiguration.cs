using EstadisticasIndependiente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EstadisticasIndependiente.Infrastructure.Data.Configurations
{
    public class PronosticoConfiguration : IEntityTypeConfiguration<Pronostico>
    {
        public void Configure(EntityTypeBuilder<Pronostico> builder)
        {
            builder.Property(t => t.PartidoId)
                .IsRequired();
            builder.Property(t => t.Resultado)
                .IsRequired();  
        }
    }

}

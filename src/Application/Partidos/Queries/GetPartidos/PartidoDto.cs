using EstadisticasIndependiente.Domain.Entities;

namespace EstadisticasIndependiente.Application.Partidos.Queries.GetPartidos
{
    public class PartidoDto
    {
        public int Id { get; init; }

        public string EquipoLocal { get; init; } = string.Empty;
        public string EquipoVisitante { get; init; } = string.Empty;

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Partido, PartidoDto>();
            }
        }
    }
}

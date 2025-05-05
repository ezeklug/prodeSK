using EstadisticasIndependiente.Application.Common.Interfaces;
using EstadisticasIndependiente.Application.Common.Security;
using EstadisticasIndependiente.Application.Partidos.Queries.GetPartidos;

namespace EstadisticasIndependiente.Application.Partidos.GetPartidos
{
    [Authorize]
    public record GetPartidosQuery : IRequest<IEnumerable<PartidoDto>>;

public class GetPartidosQueryHandler : IRequestHandler<GetPartidosQuery, IEnumerable<PartidoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPartidosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PartidoDto>> Handle(GetPartidosQuery request, CancellationToken cancellationToken)
        {
            var partidos = await _context.Partidos
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var resultado = partidos
                .GroupBy(p => p.Iteracion)
                .OrderByDescending(g => g.Key)
                .SelectMany(g => g)
                .AsQueryable()
                .ProjectTo<PartidoDto>(_mapper.ConfigurationProvider)
                .ToList();

            return resultado;
        }
    }
}

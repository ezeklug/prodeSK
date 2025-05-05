using EstadisticasIndependiente.Application.Common.Interfaces;
using EstadisticasIndependiente.Domain.Entities;
using EstadisticasIndependiente.Domain.Enums;

namespace EstadisticasIndependiente.Application.Pronosticos.Commands;

public record GuardarPronosticosCommand : IRequest<bool>
{
    public required IEnumerable<PronosticoDto> Pronosticos { get; init; }
}

public class GuardarPronosticosCommandHandler : IRequestHandler<GuardarPronosticosCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public GuardarPronosticosCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(GuardarPronosticosCommand request, CancellationToken cancellationToken)
    {
        var entities = new List<Pronostico>();

        foreach (var pronostico in request.Pronosticos)
        {
            var entity = new Pronostico
            {
                Resultado = (ResultadoPronostico)pronostico.Resultado,
                PartidoId = pronostico.PartidoId
            };
            entities.Add(entity);
        }

        _context.Pronosticos.AddRange(entities);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

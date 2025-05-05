using EstadisticasIndependiente.Application.Partidos.GetPartidos;
using EstadisticasIndependiente.Application.Partidos.Queries.GetPartidos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EstadisticasIndependiente.Web.Endpoints;

public class Partidos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPartidos);
    }

    public async Task<Ok<IEnumerable<PartidoDto>>> GetPartidos(ISender sender)
    {
        var partidos = await sender.Send(new GetPartidosQuery());
        
        return TypedResults.Ok(partidos);
    }
}

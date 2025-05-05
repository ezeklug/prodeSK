using EstadisticasIndependiente.Application.Pronosticos.Commands;

namespace EstadisticasIndependiente.Web.Endpoints;

public class Pronosticos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(GuardarPronosticos);
    }

    public async Task<bool> GuardarPronosticos(ISender sender, GuardarPronosticosCommand command)
    {
        try
        {
            var result = await sender.Send(command);

            return result;
        }
        catch
        {
            return false; 
        }
    }

}

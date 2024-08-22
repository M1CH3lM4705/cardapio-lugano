using CardapioLugano.API.Common;
using CardapioLugano.API.Services.Interfaces;

namespace CardapioLugano.API.Endpoints.Neighborhood;

public class GetNeighborhood : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync);
    }
    private static async Task<IResult> HandleAsync(INeighborhoodService neighborhoodService)
    {

        var neighborhood = await neighborhoodService.GetNeighborhood();

        return Results.Ok(neighborhood);
    }
}

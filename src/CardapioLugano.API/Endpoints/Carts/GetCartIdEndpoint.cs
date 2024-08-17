using CardapioLugano.API.Common;
using CardapioLugano.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Carts;

public class GetCartIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("{id}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync([FromServices] ICartServices cartServices, string id)
    {
        var result = await cartServices.GetByIdAsync(id);

        if (!result.IsSuccess)
            return Results.NotFound();

        return Results.Ok(result);
    }
}

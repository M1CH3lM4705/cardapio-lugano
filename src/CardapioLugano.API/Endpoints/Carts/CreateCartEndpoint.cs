using CardapioLugano.API.Common;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Carts;

public class CreateCartEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", HandleAsync);
    }

    private static async Task<IResult> HandleAsync([FromServices] ICartServices cartServices, CartRequest cartRequest)
    {
        var result = await cartServices.CreateAsync(cartRequest);

        if (!result.IsSuccess) {
            return Results.Problem(detail:result.Message);
        }

        return Results.Ok(result.Data!.Id);
    }
}

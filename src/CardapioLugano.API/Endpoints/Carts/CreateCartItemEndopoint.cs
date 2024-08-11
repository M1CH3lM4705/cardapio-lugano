using CardapioLugano.API.Common;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Carts;

public class CreateCartItemEndopoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("add-cart-item", HandleAsync);
    }

    private static async Task<IResult> HandleAsync([FromServices] ICartServices cartServices, CartItemRequest req)
    {
        var result = await cartServices.AddCartItem(req);

        return Results.Ok(result);
    }
}

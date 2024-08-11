using CardapioLugano.API.Common;
using CardapioLugano.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Carts;

public class DeleteCartItemEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("remove-cart-item/{id}", HandleAsync);
    }

    private static async Task<IResult> HandleAsync([FromServices] ICartServices cartServices, string id)
    {
        await cartServices.RemoveCartItem(id);

        return Results.NoContent();
    }
}

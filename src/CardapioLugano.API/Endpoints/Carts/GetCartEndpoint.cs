using CardapioLugano.API.Common;
using CardapioLugano.API.Extensions;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Carts;

public class GetCartEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("", HandleAsync);
    }

    private static async Task<IResult> HandleAsync([FromServices] IDal<Cart> dal)
    {
        var listDocumentsCart = await dal.ListDocuments();

        if (listDocumentsCart is null or { Total: 0 })
            return Results.NoContent();

        return Results.Ok(listDocumentsCart.DocumentListToCartsResponseList());
    }
}

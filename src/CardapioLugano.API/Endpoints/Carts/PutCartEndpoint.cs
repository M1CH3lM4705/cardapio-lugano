using Appwrite;
using CardapioLugano.API.Common;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Carts;

public class PutCartEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("", HandleAsync);
    }

    private static async Task<IResult> HandleAsync([FromServices] IDal<Cart> dal, [FromBody] CartRequest req, string id)
    {
        var order = new Cart(req.CustomerId!, null);

        try
        {
            var document = await dal.UpdateDocument(id, order);

            CartResponse res = (Cart)document;

            return Results.Ok(res);
        }
        catch (AppwriteException ex)
        {

            return Results.Problem(type: ex.Type, title: ex.Message, statusCode: ex.Code);
        }
    }
}

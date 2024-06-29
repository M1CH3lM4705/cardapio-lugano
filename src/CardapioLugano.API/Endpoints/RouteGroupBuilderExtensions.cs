using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class RouteGroupBuilderExtensions
{
    public static RouteGroupBuilder MapDeleteEndpoint<T>(this RouteGroupBuilder builder) where T : BaseModel
    {
        builder.MapDelete("", async ([FromServices] IDal<T> dal, string id) =>
        {
            var existe = await dal.GetDocument(id);

            if (existe.Id != id)
                return Results.NotFound();

            var result = await dal.DeleteDocument(id);

            return Results.Ok(result);
        });

        return builder;
    }
}

using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class ProductsExtensions
{
    public static void MapEndpointsProducts(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("products").WithTags("Products");

        groupBuilder.MapGet("", async ([FromServices] DAL<Product> dal) =>
        {
            var listadocumentos = await dal.ListDocuments();

            if (listadocumentos is null or { Total: 0 })
            {
                return Results.NotFound();
            }
            
            return Results.Ok();
        });
    }
}

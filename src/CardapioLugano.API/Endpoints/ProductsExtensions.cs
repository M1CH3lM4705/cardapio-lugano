using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class ProductsExtensions
{
    public static void AddEndpointsProducts(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("products").RequireAuthorization().WithTags("Products");

        groupBuilder.MapGet("", ([FromServices] DAL<Product> dal) =>
        {
            var listaDeArtistas = dal.ListDocuments("products");
            if (listaDeArtistas is null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok();
        });
    }
}

using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class CategoriesExtensions
{
    public static void MapEndpointsCategories(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("categories").WithTags("Categories");

        groupBuilder.MapGet("", async ([FromServices] DAL<Category> dal) =>
        {
            var listaDocumento = await dal.ListDocuments();

            if (listaDocumento is null or { Total: 0 })
            {
                return Results.NotFound();
            }

            return Results.Ok(listaDocumento);
        });

        groupBuilder.MapGet("/{id}", async ([FromServices] DAL<Category> dal, string id) =>
        {
            var documento = await dal.GetDocument(id);

            if (documento is null)
                return Results.NotFound();

            var category = new Category().ConvertTo<Category>(documento);

            return Results.Ok(category);
        });
    }
}

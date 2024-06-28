using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
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

            return Results.Ok(listadocumentos.DocumentListToProductResponseList());
        });

        groupBuilder.MapGet("{id}", async ([FromServices] DAL<Product> dal, string id) =>
        {
            var document = await dal.GetDocument(id);

            if (document is null)
                return Results.NotFound();

            ProductResponse product = (Product)document;

            return Results.Ok(product);
        });

        groupBuilder.MapPost("", async ([FromServices] DAL<Product> dal, ProductRequest req) =>
        {
            var product = new Product(
                    req.Name,
                    req.Description,
                    req.Price,
                    req.StockQuantity,
                    req.CategoryId
                );

            try
            {
                await dal.CreateDocument(product);
            }
            catch (AppwriteException ex)
            {

                return Results.BadRequest(ex);
            }

            return Results.Created();
        });

        groupBuilder.MapPut("{id}", async ([FromServices] DAL<Product> dal, string id, ProductRequest req) =>
        {
            var product = new Product(
                    req.Name,
                    req.Description,
                    req.Price,
                    req.StockQuantity,
                    req.CategoryId
                );

            try
            {
                var document = await dal.UpdateDocument(id, product);

                ProductResponse res = (Product)document;

                return Results.Ok(res);
            }
            catch (AppwriteException ex)
            {

                return Results.Problem(detail: ex.Message, statusCode: ex.Code);
            }
        });

        groupBuilder.MapDelete("{id}", async ([FromServices] DAL<Product> dal, string id) =>
        {
            var existe = await dal.GetDocument(id);

            if (existe.Id != id)
                return Results.NotFound();

            var result = await dal.DeleteDocument(id);

            return Results.Ok(result);
        });
    }
}

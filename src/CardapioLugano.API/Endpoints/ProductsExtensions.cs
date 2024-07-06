using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.API.Utils;
using CardapioLugano.Data.Authentication;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class ProductsExtensions
{
    public static void MapEndpointsProducts(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("products").WithTags("Products")
            .DisableAntiforgery()
            .RequireAuthorization();

        groupBuilder.MapGet("", async ([FromServices] IDal<Product> dal) =>
        {
            var listadocumentos = await dal.ListDocuments();

            if (listadocumentos is null or { Total: 0 })
            {
                return Results.NoContent();
            }

            return Results.Ok(listadocumentos.DocumentListToProductResponseList());
        }).WithOrder(1);

        groupBuilder.MapGet("{id}", async ([FromServices] IProductService service, string id) =>
        {
            if(string.IsNullOrEmpty(id))
                return Results.BadRequest();

            ProductResponse product = await service.GetProductAsync(id);

            return Results.Ok(product);
        }).WithOrder(2);

        groupBuilder.MapPost("", async ([FromServices] IDal<Product> dal, ProductRequest req) =>
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
        }).WithOrder(3);

        groupBuilder.MapPut("{id}", async ([FromServices] IDal<Product> dal, string id, ProductRequest req) =>
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
        }).WithOrder(4);

        groupBuilder.MapPost("{id}/upload", async (
            [FromServices] IProductService service,
            string id, 
            IFormFile file
            ) =>
        {
            if (!file.ValidateFile() && string.IsNullOrEmpty(id))
                return Results.BadRequest();

            await service.UploadProductImageAsync(id, file);

            return Results.Ok();
        }).WithOrder(5);

        groupBuilder.MapDeleteEndpoint<Product>();
    }
}

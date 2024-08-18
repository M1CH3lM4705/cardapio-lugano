using Appwrite;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.API.Utils;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;
using CardapioLugano.Shared.Responses;
using CardapioLugano.Shared.Requests;

namespace CardapioLugano.API.Endpoints;

public static class ProductsExtensions
{
    public static void MapEndpointsProducts(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("products").WithTags("Products")
            .DisableAntiforgery();

        groupBuilder.MapGet("", async ([FromServices] IProductService service) =>
        {
            var result = await service.GetAll();

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }).WithOrder(1).AllowAnonymous();

        groupBuilder.MapGet("{id}", async ([FromServices] IProductService service, string id) =>
        {
            if(string.IsNullOrEmpty(id))
                return Results.BadRequest();

            ProductResponse product = await service.GetProductAsync(id);

            return Results.Ok(product);
        }).WithOrder(2).AllowAnonymous();

        groupBuilder.MapPost("", async ([FromServices] IProductService service, ProductRequest req) =>
        {
            var result = await service.CreateProductAsync(req);

            return result.IsSuccess ?
                Results.Ok(result) : 
                Results.BadRequest(result);

        }).WithOrder(3)
            .RequireAuthorization();

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
        }).WithOrder(4)
            .RequireAuthorization();

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
        }).WithOrder(5)
            .RequireAuthorization();

        groupBuilder.MapDeleteEndpoint<Product>()
            .RequireAuthorization();
    }
}

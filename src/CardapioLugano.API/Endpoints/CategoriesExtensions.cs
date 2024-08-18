using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CardapioLugano.API.Endpoints;

public static class CategoriesExtensions
{
    public static void MapEndpointsCategories(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("categories").WithTags("Categories");

        groupBuilder.MapGet("", async ([FromServices] IDal<Category> dal) =>
        {
            var listaDocumento = await dal.ListDocuments();

            if (listaDocumento is null or { Total: 0 })
            {
                return Results.NotFound();
            }

            var result = listaDocumento.DocumentListToCategoryResponseList();

            var response = new PagedResponse<List<CategoryResponse>>(result, 200, (int)listaDocumento.Total);

            return Results.Ok(response);
        }).RequireAuthorization();

        groupBuilder.MapGet("/{id}", async ([FromServices] IDal<Category> dal, string id) =>
        {
            var documento = await dal.GetDocument(id);

            if (documento is null)
                return Results.NotFound();

            var category = new Category().ConvertTo<Category>(documento);

            return Results.Ok(category);
        });

        groupBuilder.MapPost("", async ([FromServices] IDal<Category> dal, [FromBody]CategoryRequest req) =>
        {
            var category = new Category(req.Name);

            try
            {
                var result = await dal.CreateDocument(category);

                return Results.Created();
            }
            catch (AppwriteException ex)
            {

                return Results.Problem(title: "Erro a cadastar categoria", detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }

        });

        groupBuilder.MapPut("", async ([FromServices] IDal<Category> dal, [FromBody] CategoryRequest req) =>
        {
            var category = new Category(req.Name);

            try
            {
                var document = await dal.UpdateDocument(req.Id!, category);

                Category res = (Category)document;

                return Results.Ok(res);
            }
            catch (AppwriteException ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: ex.Code);
            }
        });

        groupBuilder.MapDeleteEndpoint<Category>();
    }
}

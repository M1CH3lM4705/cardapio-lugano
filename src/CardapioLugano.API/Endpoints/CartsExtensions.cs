using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class CartsExtensions
{
    public static void MapEndpointsCarts(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("cart").WithTags("Cart");

        groupBuilder.MapGet("", async ([FromServices] IDal<Cart> dal) =>
        {
            var listDocumentsCart = await dal.ListDocuments();

            if (listDocumentsCart is null or { Total: 0 })
                return Results.NoContent();

            return Results.Ok(listDocumentsCart.DocumentListToCartsResponseList());
        });

        groupBuilder.MapGet("{id}", async ([FromServices] IDal<Cart> dal, string id) =>
        {
            var documento = await dal.GetDocument(id);

            if (documento is null)
                return Results.NotFound();

            CartResponse cart = (Cart)documento;

            return Results.Ok(cart);
        });

        groupBuilder.MapPost("", async ([FromServices] IDal<Cart> dal, [FromBody] CartRequest req) =>
        {
            var cart = new Cart(req.CustomerId!, null);

            try
            {
                var result = await dal.CreateDocument(cart);

                return Results.Created("", result.Id);
            }
            catch (AppwriteException ex)
            {

                return Results.Problem(type: ex.Type, title: ex.Message, statusCode: ex.Code);
            }
        });

        groupBuilder.MapPost("add-cart-item", async ([FromServices] ICartServices cartServices, CartItemRequest req) =>
        {
            var result = await cartServices.AddCartItem(req);

            return Results.Ok(result);
        });

        groupBuilder.MapDelete("remove-cart-item/{id}", async ([FromServices] ICartServices cartServices, string id) =>
        {
            await cartServices.RemoveCartItem(id);

            return Results.NoContent();
        });

        groupBuilder.MapPut("{id}", async ([FromServices] IDal<Cart> dal, [FromBody] CartRequest req, string id) =>
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
        });

        groupBuilder.MapDeleteEndpoint<Cart>().WithOrder(5);


    }
}

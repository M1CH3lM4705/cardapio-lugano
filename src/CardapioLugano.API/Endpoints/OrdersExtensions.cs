using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class OrdersExtensions
{
    public static void MapEndpointsOrders(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("orders").WithTags("Orders");

        groupBuilder.MapGet("", async ([FromServices]IDal<Order> dal) =>
        {
            var listaOrdersDocument = await dal.ListDocuments();

            if (listaOrdersDocument is null or { Total: 0 })
                return Results.NoContent();

            return Results.Ok(listaOrdersDocument.DocumentListToOrderResponseList());
        });

        groupBuilder.MapGet("{id}", async ([FromServices]IDal<Order> dal, string id) =>
        {
            var documento = await dal.GetDocument(id);

            if(documento is null)
                return Results.NotFound();

            OrderResponse order = (Order)documento;

            return Results.Ok(order);
        });

        groupBuilder.MapPost("", async ([FromServices]IDal<Order> dal, [FromBody] OrderRequest req) =>
        {
            var order = new Order(req.CustomerId, req.TotalAmount, req.Status);

            try
            {
                await dal.CreateDocument(order);

                return Results.Created();
            }
            catch (AppwriteException ex)
            {

                return Results.Problem(type:ex.Type, title:ex.Message, statusCode:ex.Code);
            }
        });

        groupBuilder.MapPut("", async ([FromServices] IDal<Order> dal, [FromBody] OrderRequest req) =>
        {
            var order = new Order(req.CustomerId, req.TotalAmount, req.Status);

            try
            {
                var document = await dal.UpdateDocument(req.OrderId!, order);

                OrderResponse res = (Order)document;

                return Results.Ok(res);
            }
            catch (AppwriteException ex)
            {

                return Results.Problem(type: ex.Type, title: ex.Message, statusCode: ex.Code);
            }
        });

        groupBuilder.MapDeleteEndpoint<Order>();
    }
}

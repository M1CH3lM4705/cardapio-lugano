﻿using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class OrderItemsExtensions
{
    public static void MapEndpointsOrderItems(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("order-items").WithTags("Order Items");

        groupBuilder.MapGet("", async ([FromServices] IDal<OrderItem> dal) =>
        {
            var documentsOrderItems = await dal.ListDocuments();

            if (documentsOrderItems is null or { Total: 0 })
                return Results.NoContent();

            return Results.Ok(documentsOrderItems.DocumentListToOrderItemsResponseList());
        });

        groupBuilder.MapGet("{id}", async ([FromServices] IDal<OrderItem> dal, string id) =>
        {
            var document = await dal.GetDocument(id);

            if (document is null)
                return Results.NotFound();

            OrderItemResponse orderItem = (OrderItem)document;

            return Results.Ok(orderItem);
        });

        groupBuilder.MapPost("", async ([FromServices] IDal<OrderItem> dal, OrderItemRequest req) =>
        {
            var orderItem = new OrderItem(req.Quantity, req.UnitPrice, req.OrderId, req.ProductId);
            try
            {
                await dal.CreateDocument(orderItem);
            }
            catch (AppwriteException ex)
            {

                return Results.BadRequest(ex);
            }

            return Results.Created();
        });

        groupBuilder.MapPut("{id}", async ([FromServices] IDal<OrderItem> dal, string id, OrderItemRequest req) =>
        {
            var orderItem = new OrderItem(
                    req.Quantity,
                    req.UnitPrice,
                    req.OrderId,
                    req.ProductId
                );

            try
            {
                var document = await dal.UpdateDocument(id, orderItem);

                OrderItemResponse res = (OrderItem)document;

                return Results.Ok(res);
            }
            catch (AppwriteException ex)
            {

                return Results.Problem(detail: ex.Message, statusCode: ex.Code);
            }
        });

        groupBuilder.MapDelete("{id}", async ([FromServices] IDal<OrderItem> dal, string id) =>
        {
            var existe = await dal.GetDocument(id);

            if (existe.Id != id)
                return Results.NotFound();

            var result = await dal.DeleteDocument(id);

            return Results.Ok(result);
        });
    }
}
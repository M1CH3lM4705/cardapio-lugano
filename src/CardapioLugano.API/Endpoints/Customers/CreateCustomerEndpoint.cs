using CardapioLugano.API.Common;
using CardapioLugano.Shared.Requests;
using CardapioLugano.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints.Customers;

public class CreateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync);

    private static async Task<IResult> HandleAsync([FromServices]ICustomerService service, CustomerRequest req)
    {
        if (req is null) return Results.BadRequest();

        var customer = await service.CreateAsync(req);

        return Results.Ok(customer);
    }
}

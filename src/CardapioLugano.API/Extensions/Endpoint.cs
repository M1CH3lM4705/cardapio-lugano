using CardapioLugano.API.Common;
using CardapioLugano.API.Endpoints;
using CardapioLugano.API.Endpoints.Carts;
using CardapioLugano.API.Endpoints.Customers;
using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Extensions;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/customers")
            .WithTags("Customers")
            .AllowAnonymous()
            .MapDeleteEndpoint<Customer>()
            .MapEndpoint<CreateCustomerEndpoint>();

        endpoints.MapGroup("/cart")
            .WithTags("Carts")
            .AllowAnonymous()
            .MapDeleteEndpoint<Cart>()
            .MapEndpoint<GetCartEndpoint>()
            .MapEndpoint<GetCartIdEndpoint>()
            .MapEndpoint<CreateCartEndpoint>()
            .MapEndpoint<CreateCartItemEndopoint>()
            .MapEndpoint<PutCartEndpoint>()
            .MapEndpoint<DeleteCartItemEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
    {
        T.Map(app);

        return app;
    }
}

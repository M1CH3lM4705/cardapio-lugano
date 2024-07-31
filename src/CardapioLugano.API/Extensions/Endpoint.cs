using CardapioLugano.API.Common;
using CardapioLugano.API.Endpoints.Customers;

namespace CardapioLugano.API.Extensions;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/customers")
            .WithTags("Customers")
            .AllowAnonymous()
            .MapEndpoint<CreateCustomerEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
    {
        T.Map(app);

        return app;
    }
}

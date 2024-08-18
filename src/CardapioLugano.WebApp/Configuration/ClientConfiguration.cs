using CardapioLugano.WebApp.Services;

namespace CardapioLugano.WebApp.Configuration;

public static class ClientConfiguration
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.
            AddHttpClient(
            WebConfiguration.ClientName,
            opt =>
            {
                opt.BaseAddress = new Uri(WebConfiguration.BackendUrl ?? "https://localhost:7290");
            })
            .AddHttpMessageHandler<HttpHandler>();
    }
}

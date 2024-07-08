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
                opt.BaseAddress = new Uri(WebConfiguration.BackendUrl);
            });
    }
}

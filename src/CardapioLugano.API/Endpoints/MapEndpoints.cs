namespace CardapioLugano.API.Endpoints;

public static class MapEndpoints
{
    public static void MapEndpointsApi(this WebApplication app)
    {
        app.MapEndpointsProducts();
        app.MapEndpointsCategories();
        app.MapEndpointsOrders();
        app.MapEndpointsOrderItems();
        app.MapEndpointsCarts();
            
    }
}

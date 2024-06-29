using CardapioLugano.Data.Configurations;
using CardapioLugano.Data.Persistence;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Injections;

public static class DependencyInjections
{
    public static void AddServicesInjection(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AppwriteConfiguration>(config.GetSection(nameof(AppwriteConfiguration)));

        services.AddSingleton<IAppwriteBase, AppwriteBase>();

        services.AddTransient(typeof(IDal<>), typeof(DAL<>));

        services.AddTransient<IDal<Product>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            return new DAL<Product>(Product.Products, appwriteService);
        });

        services.AddTransient<IDal<Category>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            return new DAL<Category>(Category.Categories, appwriteService);
        });

        services.AddTransient<IDal<Order>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            return new DAL<Order>(Order.Orders, appwriteService);
        });

        services.AddTransient<IDal<OrderItem>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            return new DAL<OrderItem>(OrderItem.OrderItems, appwriteService);
        });
    }
}

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

        services.AddTransient(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            return new DAL<Product>(Product.Products, appwriteService);
        });

        services.AddTransient(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            return new DAL<Category>(Category.Categories, appwriteService);
        });
    }
}

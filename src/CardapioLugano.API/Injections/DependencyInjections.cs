using CardapioLugano.API.Services;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Data.Configurations;
using CardapioLugano.Data.Persistence;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Data.Token;
using CardapioLugano.Modelos.Models;
using Microsoft.Extensions.Options;

namespace CardapioLugano.API.Injections;

public static class DependencyInjections
{
    public static void AddServicesInjection(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AppwriteConfiguration>(config.GetSection(nameof(AppwriteConfiguration)));

        services.AddHttpContextAccessor();

        services.AddTransient<AuthenticatedUser>();

        services.AddTransient<IAppwriteBase, AppwriteBase>();

        services.AddTransient(typeof(IDal<>), typeof(DAL<>));

        services.AddTransient<IDal<Product>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<Product>(Product.Products, appwriteService, userService, options);
        });

        services.AddTransient<IDal<Category>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<Category>(Category.Categories, appwriteService, userService, options);
        });

        services.AddTransient<IDal<Order>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<Order>(Order.Orders, appwriteService, userService, options);
        });

        services.AddTransient<IDal<OrderItem>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<OrderItem>(OrderItem.OrderItems, appwriteService, userService, options);
        });

        services.AddTransient<IDal<Cart>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<Cart>(Cart.Carts, appwriteService, userService, options);
        });

        services.AddTransient<IDal<CartItem>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<CartItem>(CartItem.CartItems, appwriteService, userService, options);
        });

        services.AddTransient<IDal<Image>>(sp =>
        {
            var appwriteService = sp.GetRequiredService<IAppwriteBase>();

            var userService = sp.GetRequiredService<AuthenticatedUser>();

            var options = sp.GetRequiredService<IOptions<AppwriteConfiguration>>();

            return new DAL<Image>(Image.Images, appwriteService, userService, options);
        });

        services.AddTransient<ICartServices, CartServices>();

        services.AddTransient<IProductService, ProductService>();
        
        services.AddTransient<ITokenGenerator, TokenGenerator>();
    }
}

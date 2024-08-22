using Blazored.LocalStorage;
using CardapioLugano.WebApp;
using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.GlobalState;
using CardapioLugano.WebApp.Services;
using CardapioLugano.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);
builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();
builder.Services.AddTransient(sp => (AuthService)sp.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddScoped<HttpHandler>();
builder.Services.AddSingleton<IPublisher, Publisher>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<CartService>();
builder.Services.AddSingleton<CartState>();
builder.Services.AddTransient<NeighborhoodService>();

builder.Services.AddHttpClients();


await builder.Build().RunAsync();

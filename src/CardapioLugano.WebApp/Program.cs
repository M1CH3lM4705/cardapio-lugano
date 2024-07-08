using CardapioLugano.WebApp;
using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClients();

builder.Services.AddTransient<ProductService>();

await builder.Build().RunAsync();

using Appwrite;
using CardapioLugano.Data.Persistence;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(sp =>
{
    var client = new Client()
        .SetEndpoint("")
        .SetProject("")
        .SetKey("");

    return client;
});

builder.Services.AddScoped<IAppwriteBase, AppwriteBase>();
builder.Services.AddTransient(sp =>
{
    var appwriteService = sp.GetRequiredService<AppwriteBase>();
    return new DAL<Product>("products", appwriteService);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


using CardapioLugano.API.Configuration;
using CardapioLugano.API.Endpoints;
using CardapioLugano.API.Extensions;
using CardapioLugano.API.Injections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddCrossOrigin();

builder.Services.AddAuthenticationWithToken(builder.Configuration);

builder.Services.AddServicesInjection(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("wasm");

app.MapEndpoints();

app.MapEndpointsApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


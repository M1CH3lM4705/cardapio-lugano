using CardapioLugano.API.Endpoints;
using CardapioLugano.API.Injections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServicesInjection(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapEndpointsProducts();
app.MapEndpointsCategories();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


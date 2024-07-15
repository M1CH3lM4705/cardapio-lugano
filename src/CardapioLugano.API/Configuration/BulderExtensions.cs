namespace CardapioLugano.API.Configuration;

public static class BulderExtensions
{
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
        options => options.AddPolicy(
                "wasm",
                policy => policy
                    .WithOrigins([
                        "https://localhost:7290",
                        "https://localhost:7058"
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }
}

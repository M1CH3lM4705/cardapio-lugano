using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CardapioLugano.API.Injections;

public static class AuthConfiguration
{
    public static void AddAuthenticationWithToken(this IServiceCollection services, IConfiguration config)
    {
        var key = Encoding.ASCII.GetBytes(config.GetValue<string>("ApiKey")!);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        services.AddAuthorization();
    }
}

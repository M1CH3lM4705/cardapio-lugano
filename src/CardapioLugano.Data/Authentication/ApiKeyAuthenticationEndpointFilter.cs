using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CardapioLugano.Data.Authentication;
public class ApiKeyAuthenticationEndpointFilter : IEndpointFilter
{
    private const string ApiKeyHeaderName = "X-Api-Key";

    private readonly IConfiguration _configuration;

    public ApiKeyAuthenticationEndpointFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        string? apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];

        if (!IsApiKeyValid(apiKey))
        {
            return Results.Unauthorized();
        }

        return await next(context);
    }

    private bool IsApiKeyValid(string? apiKey)
    {
        if (!string.IsNullOrEmpty(apiKey))
        {
            return false;
        }

        string actualApiKey = _configuration.GetValue<string>("ApiKey")!;

        return apiKey == actualApiKey;
    }
}

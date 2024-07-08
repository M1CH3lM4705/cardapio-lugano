using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace CardapioLugano.WebApp.Services;

public class AuthService(IHttpClientFactory httpClientFactory) : AuthenticationStateProvider
{
    private bool autenticado = false;
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.ClientName);

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        autenticado = false;

        throw new NotImplementedException();
    }

    public async Task<Response<string>> LoginAsync(LoginRequest login)
    {
        var result = await _client.PostAsJsonAsync("auth/login", login);
        var token = await result.Content.ReadFromJsonAsync<string>();
        if (result.IsSuccessStatusCode)
        {
            return new Response<string>(token);
        }

        return new Response<string>(null, 401, "Usuário ou senha inválidos");
    }
}

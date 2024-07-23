using Blazored.LocalStorage;
using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace CardapioLugano.WebApp.Services;

public class AuthService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorage) : AuthenticationStateProvider
{
    private bool autenticado = false;
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.ClientName);

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await localStorage.GetItemAsync<string>("token");
        var identity = string.IsNullOrEmpty(token) ? new ClaimsIdentity() : new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        if (!string.IsNullOrEmpty(token))
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

    public async Task<Response<LoginResponse>> LoginAsync(LoginRequest login)
    {
        var response = await _client.PostAsJsonAsync("auth/login", login);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Response<LoginResponse>>();
            await localStorage.SetItemAsync("token", result!.Data!.Token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Data.Token);
            return result;
        }
        return new Response<LoginResponse>(null, 401, "Usuário ou senha inválidos");
    }

    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }
}

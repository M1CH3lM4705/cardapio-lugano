using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using System.Net;
using System.Net.Http.Json;

namespace CardapioLugano.WebApp.Services;

public class ProductService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.ClientName);
    public async Task<PagedResponse<List<ProductResponse>?>> GetAllAsync() =>
        await _client.GetFromJsonAsync<PagedResponse<List<ProductResponse>?>>("products")
            ?? new PagedResponse<List<ProductResponse>?>(null, (int)HttpStatusCode.BadRequest, "Não foi possível obter os produtos");

    public async Task<Response<string>> LoginAsync(LoginRequest login)
    {
        var result = await _client.PostAsJsonAsync("auth/login", login);
        var token = await result.Content.ReadFromJsonAsync<string>();
        if(result.IsSuccessStatusCode)
        {
            return new Response<string>(token);
        }

        return new Response<string>(null, 401, "Usuário ou senha inválidos");
    }

    internal async Task CreateProduct(ProductRequest request)
    {
        throw new NotImplementedException();
    }

    internal async Task<ICollection<CategoryResponse>?> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }
}

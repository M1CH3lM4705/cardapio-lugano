using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.Responses;
using System.Net;
using System.Net.Http.Json;

namespace CardapioLugano.WebApp.Services;

public class CategoryService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.ClientName);
    internal async Task<PagedResponse<List<CategoryResponse>?>> GetAllCategoriesAsync()
    {
        var result = await _client.GetFromJsonAsync<PagedResponse<List<CategoryResponse>?>>("categories") ??
            new PagedResponse<List<CategoryResponse>?>(null, (int)HttpStatusCode.BadRequest, "Não foi possível obter os produtos");

        return result;
    }
}

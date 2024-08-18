using CardapioLugano.WebApp.Configuration;
using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;
using Microsoft.AspNetCore.Components.Forms;
using System.Net;
using System.Net.Http.Json;

namespace CardapioLugano.WebApp.Services;

public class ProductService(IHttpClientFactory httpClientFactory) : Service
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.ClientName);
    public async Task<PagedResponse<List<ProductResponse>?>> GetAllAsync() =>
        await _client.GetFromJsonAsync<PagedResponse<List<ProductResponse>?>>("products")
            ?? new PagedResponse<List<ProductResponse>?>(null, (int)HttpStatusCode.BadRequest, "Não foi possível obter os produtos");

    public async Task<Response<ProductResponse>> CreateProduct(ProductRequest request)
    {
        var result = await _client.PostAsJsonAsync("products", request);
        var produto = await DeserializarObjetoResponse<Response<ProductResponse>>(result);
        
        if (TratarErrosResponse(result))
        {
            return produto;
        }

        return new Response<ProductResponse>(null, (int)result.StatusCode, produto.Message);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var result = await _client.DeleteAsync($"products/{id}");

        return await DeserializarObjetoResponse<bool>(result);
    }

    public async Task UploadFileAsync(string id, IBrowserFile file)
    {
        try
        {
            await _client.PostAsync($"products/{id}/upload", ContentForm(file));
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }

    internal async Task UpdateAsync(ProductRequest request)
    {
        await _client.PutAsJsonAsync($"products/{request.Id}", request);
    }
}

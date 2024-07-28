using CardapioLugano.WebApp.Configuration;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using System.Net.Http.Json;

namespace CardapioLugano.WebApp.Services;

public class CartService(IHttpClientFactory httpClientFactory) : Service
{
    private readonly HttpClient _client =  httpClientFactory.CreateClient(WebConfiguration.ClientName);

    public async Task<string> CreateCartAsync(CartRequest request)
    {
       var result = await _client.PostAsJsonAsync("cart", request);

        return await DeserializarObjetoResponse<string>(result);
    }
    public async Task AddItemCartAsync(CartItemRequest request)
    {
        await _client.PostAsJsonAsync("cart/add-cart-item", request);
    }

    public async Task<CartResponse?> GetCartByIdAsync(string id)
    {
        return await _client.GetFromJsonAsync<CartResponse?>($"cart/{id}");
    }

    internal async Task RemoveCartAsync(CartItemRequest req)
    {
        await _client.DeleteAsync($"cart/remove-cart-item/{req.Id}");
    }
}

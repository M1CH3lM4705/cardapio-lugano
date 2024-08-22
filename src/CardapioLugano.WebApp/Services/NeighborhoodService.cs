using CardapioLugano.Modelos.Models;
using CardapioLugano.Shared.Responses;
using CardapioLugano.WebApp.Configuration;
using System.Net.Http.Json;

namespace CardapioLugano.WebApp.Services;

public class NeighborhoodService(IHttpClientFactory clientFactory)
{
    private readonly HttpClient _client = clientFactory.CreateClient(WebConfiguration.ClientName);
    public async Task<Response<ICollection<Neighborhood>>> GetNeighborhood() =>
        await _client.GetFromJsonAsync<Response<ICollection<Neighborhood>>>("neighborhood");
}

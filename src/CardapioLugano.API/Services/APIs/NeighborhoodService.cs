using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Modelos.Models;
using CardapioLugano.Shared.Responses;

namespace CardapioLugano.API.Services.APIs;

public class NeighborhoodService(HttpClient client) : INeighborhoodService
{
    public async Task<Response<IEnumerable<Neighborhood>>> GetNeighborhood(CancellationToken ct = default)
    {
		try
		{
            IEnumerable<Neighborhood> neighborhood = await client.GetFromJsonAsync<IEnumerable<Neighborhood>>("api/cidade/7319/bairros/", ct);

			if(neighborhood == null) return new Response<IEnumerable<Neighborhood>>(null, 404, "Nenhum registro encontrado");

            return new Response<IEnumerable<Neighborhood>>(neighborhood);
        }
		catch (Exception ex)
		{

			throw;
		}
    }

    public void Dispose()
    {
        client?.Dispose();
        GC.SuppressFinalize(this);
    }
}

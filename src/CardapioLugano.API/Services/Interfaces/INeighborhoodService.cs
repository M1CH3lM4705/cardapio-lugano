using CardapioLugano.Modelos.Models;
using CardapioLugano.Shared.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface INeighborhoodService : IDisposable
{
    Task<Response<IEnumerable<Neighborhood>>> GetNeighborhood(CancellationToken ct = default);
}

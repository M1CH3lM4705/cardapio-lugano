using CardapioLugano.Shared.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICrateAsync<TRequest, TResult>
{
    Task<Response<TResult>> CreateAsync(TRequest request);
}

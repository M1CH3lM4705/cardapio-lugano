using CardapioLugano.API.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICrateAsync<TRequest, TResult>
{
    Task<Response<TResult>> CreateAsync(TRequest request);
}

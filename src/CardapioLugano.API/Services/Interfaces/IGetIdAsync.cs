using CardapioLugano.Shared.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface IGetIdAsync<TResult>
{
    Task<Response<TResult>> GetByIdAsync(string id);
}

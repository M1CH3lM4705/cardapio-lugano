using CardapioLugano.API.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface IGetIdAsync<TResult>
{
    Task<Response<TResult>> GetByIdAsync(string id);
}

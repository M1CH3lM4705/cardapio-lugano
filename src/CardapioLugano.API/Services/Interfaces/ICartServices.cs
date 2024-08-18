using CardapioLugano.Shared.Responses;
using CardapioLugano.Shared.Requests;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICartServices : ICrateAsync<CartRequest, CartResponse>, IGetIdAsync<CartResponse>
{
    Task<Response<CartResponse>> AddCartItem(CartItemRequest cartItemRequest);
    Task RemoveCartItem(string id);
}

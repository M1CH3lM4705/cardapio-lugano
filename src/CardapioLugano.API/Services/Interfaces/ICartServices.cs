using CardapioLugano.API.Responses;
using CardapioLugano.API.Requests;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICartServices : ICrateAsync<CartRequest, CartResponse>, IGetIdAsync<CartResponse>
{
    Task<Response<CartResponse>> AddCartItem(CartItemRequest cartItemRequest);
    Task RemoveCartItem(string id);
}

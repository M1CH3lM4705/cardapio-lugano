using CardapioLugano.API.Responses;
using CardapioLugano.API.Requests;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICartServices
{
    Task<Response<CartResponse>> AddCartItem(CartItemRequest cartItemRequest);
}

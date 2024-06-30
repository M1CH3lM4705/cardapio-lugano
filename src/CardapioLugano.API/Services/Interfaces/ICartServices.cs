using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICartServices
{
    Task<CartResponse> AddCartItem(CartItemRequest cartItemRequest);
}

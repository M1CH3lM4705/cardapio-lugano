using CardapioLugano.API.Responses;
using CardapioLugano.API.Requests;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICartServices
{
    Task<CartResponse> AddCartItem(CartItemRequest cartItemRequest);
}

using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Responses;

public record CartItemResponse(string Name, int Quantity, double UnitPrice)
{
    public static implicit operator CartItemResponse(CartItem cartItem)
    {
        return new(cartItem.Name!, cartItem.Quantity, cartItem.UnitPrice);
    }
}

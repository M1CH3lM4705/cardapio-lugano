using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Responses;

public record CartItemResponse(string Id, string? ProductId, string Name, int Quantity, double UnitPrice)
{
    public static implicit operator CartItemResponse(CartItem cartItem)
    {
        return new(cartItem.Id!,cartItem.ProductId, cartItem.Name!, cartItem.Quantity, cartItem.UnitPrice);
    }
}

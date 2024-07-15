using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Responses;

public record CartResponse(string? Id, string TotalAmount, List<CartItemResponse> CartItems)
{
    public static implicit operator CartResponse(Cart cart)
    {
        var cartItemsresponses = cart.CartItems.Select<CartItem, CartItemResponse>(x => x).ToList();

        return new(cart.Id, cart.TotalAmount!.Value.ToString("C"), cartItemsresponses);
    }
}

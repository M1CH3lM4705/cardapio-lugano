using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Responses;

public record CartResponse(string? Id, string TotalAmount, List<CartItemResponse> CartItems, int TotalItems = 0)
{
    public static implicit operator CartResponse(Cart cart)
    {
        var cartItemsresponses = cart.CartItems.Select<CartItem, CartItemResponse>(x => x).ToList();

        var totalItems = cartItemsresponses.Sum(x => x.Quantity);

        return new(cart.Id, cart.TotalAmount!.Value.ToString("C"), cartItemsresponses, totalItems);
    }
}

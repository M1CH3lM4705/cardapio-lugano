using CardapioLugano.Modelos.Models;

namespace CardapioLugano.Shared.Responses;

public record CartResponse(string? Id, List<CartItemResponse> CartItems)
{
    public static implicit operator CartResponse(Cart cart)
    {
        var cartItemsresponses = cart.CartItems.Select<CartItem, CartItemResponse>(x => x).ToList();

        return new CartResponse(cart.Id, cartItemsresponses)
        {
            TotalAmount = cart.TotalAmount!.Value.ToString("C"),
            TotalItems = cartItemsresponses.Sum(x => x.Quantity)
        };
    }
    public string? TotalAmount { get; set; }

    public int TotalItems { get; set; } = 0;
    public void UpdateCart()
    {
        TotalAmount = CartItems.Sum(x => x.Quantity * x.UnitPrice).ToString("C");
        TotalItems = CartItems.Sum(x => x.Quantity);
    }
}

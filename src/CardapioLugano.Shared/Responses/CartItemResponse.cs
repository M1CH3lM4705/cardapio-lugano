using CardapioLugano.Modelos.Models;

namespace CardapioLugano.Shared.Responses;

public record CartItemResponse(string Id, string? ProductId, string Name, double UnitPrice, string UrlImage)
{
    public static implicit operator CartItemResponse(CartItem cartItem)
    {
        var cart = new CartItemResponse(cartItem.Id!, cartItem.ProductId, cartItem.Name!, cartItem.UnitPrice, cartItem.UrlImage!)
        {
            Quantity = cartItem.Quantity
        };

        return cart;
    }
    public int Quantity { get; set; }

    public void RemoveOneQuantity()
    {
        Quantity--;
    }

    public void AddOneQuantity() => Quantity++;

    public double CalculateUnitPriceForQuantity() => UnitPrice * Quantity;
}

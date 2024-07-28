namespace CardapioLugano.WebApp.Responses;

public record CartResponse(string? Id, List<CartItemResponse> CartItems)
{
    public string? TotalAmount { get; set; }

    public int TotalItems { get; set; } = 0;
    public void UpdateCart()
    {
        TotalAmount = CartItems.Sum(x => x.Quantity * x.UnitPrice).ToString("C");
        TotalItems = CartItems.Sum(x => x.Quantity);
    }
}

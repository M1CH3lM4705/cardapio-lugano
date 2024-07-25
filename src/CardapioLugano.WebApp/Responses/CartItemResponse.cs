namespace CardapioLugano.WebApp.Responses;

public record CartItemResponse(string Id, string? ProductId, string Name, double UnitPrice)
{
    public int Quantity { get; set; }

    public void RemoveOneQuantity()
    {
        Quantity--;
    }

    public void AddOneQuantity() => Quantity++;
}

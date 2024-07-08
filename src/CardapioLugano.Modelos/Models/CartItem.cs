using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Models;

public class CartItem : BaseModel
{
    public static readonly string CartItems = "shoppingCartItems";

    public CartItem()
    {

    }

    public CartItem(string? productId, int quantity, double unitPrice, string? name)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Name = name;
    }

    [JsonProperty("cartId")]
    public string? CartId { get; set; }
    [JsonProperty("productId")]
    public string? ProductId { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
    [JsonProperty("unitPrice")]
    public double UnitPrice { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "cartId", CartId },
            { "productId", ProductId },
            { "quantity", Quantity },
            { "unitPrice", UnitPrice },
            { "name", Name },
        };
    }

    public void AssociateCart(string cartId) =>
        CartId = cartId;

    public double CalculateValue() =>
        Quantity * UnitPrice;

    public void AddUnit(int unit) =>
        Quantity += unit;

    public void UpdateUnit(int unit) =>
        Quantity = unit;
}
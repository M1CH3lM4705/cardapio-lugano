
using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class Cart : BaseModel
{
    public static readonly string Carts = "shoppingCart";
    public Cart()
    {
        
    }

    public Cart(string customerId, double? totalAmout)
    {
        CustomerId = customerId;
        TotalAmount = totalAmout;
    }

    [JsonProperty("customerId")]
    public string? CustomerId { get; set; }
    
    [JsonProperty("totalAmount")]
    public double? TotalAmount { get; set; } = default;
    
    [JsonProperty("shoppingCartItems")]
    public List<CartItem> CartItems { get; set; } = [];
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "customerId", CustomerId },
            { "totalAmount", TotalAmount },
            { "shoppingCartItems", CartItems },
        };
    }

    public static implicit operator Cart(Document data) =>
        new Cart().ConvertTo<Cart>(data);
}

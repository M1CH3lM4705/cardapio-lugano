
using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class OrderItem : BaseModel
{
    public static readonly string OrderItems = "orderItems";

    public OrderItem()
    {
        
    }

    public OrderItem(int quantity, double unitPrice, string orderId, string productId)
    {
        Quantity = quantity;
        UnitPrice = unitPrice;
        Order = new Order { Id = orderId };
        Product = new Product { Id = productId };
    }

    [JsonProperty("orders")]
    public Order? Order { get; set; }
    [JsonProperty("products")]
    public Product? Product { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
    [JsonProperty("unitPrice")]
    public double UnitPrice { get; set; }
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "quantity", Quantity },
            { "unitPrice", UnitPrice },
            { "orders", Order },
            { "products", Product },
        };
    }

    public static implicit operator OrderItem(Document data)
    {
        return new OrderItem().ConvertTo<OrderItem>(data);
    }
}

using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class Order : BaseModel
{
    public static readonly string Orders = "orders";

    public Order()
    {
        
    }

    public Order(string? customerId, double totalAmount, string? status)
    {
        CustomerId = customerId;
        TotalAmount = totalAmount;
        Status = status;
    }

    [JsonProperty("customerId")]
    public string? CustomerId { get; set; }
    [JsonProperty("totalAmount")]
    public double TotalAmount { get; set; }
    [JsonProperty("status")]
    public string? Status { get; set; }
    //public List<OrderItems> OrderItems { get; set; }

    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            {"customerId", CustomerId },
            { "totalAmount", TotalAmount },
            { "status", Status }
        };
    }

    public static implicit operator Order(Document data) =>
        new Order().ConvertTo<Order>(data);
}

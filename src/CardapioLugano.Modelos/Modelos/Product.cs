using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace CardapioLugano.Modelos.Modelos;
public class Product : BaseModel
{
    [JsonPropertyName("$id")]
    public int ProductId { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("stockQuantity")]
    public int StockQuantity { get; set; }
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }
    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }

    public override BaseModel ConvertTo(Document data)
    {
        return JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(data));
    }

    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            {"name" , Name},
            {"description" , Description},
            {"price", Price},
            {"stockQuantity", StockQuantity},
            {"category" , CategoryId},
            {"createdDate", CreatedDate},
        };
    }
}

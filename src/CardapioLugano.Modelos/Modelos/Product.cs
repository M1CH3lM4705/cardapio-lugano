using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class Product : BaseModel
{

    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
    [JsonProperty("price")]
    public decimal Price { get; set; }
    [JsonProperty("stockQuantity")]
    public int StockQuantity { get; set; }
    [JsonProperty("categoryId")]
    public int CategoryId { get; set; }
    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    public override Product ConvertTo<Product>(Document data)
    {
        return JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(data))!;
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

    public static readonly string Products = "products";

    public static implicit operator Product(Document data)
    {
        return new Product().ConvertTo<Product>(data);
    }
}

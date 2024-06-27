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
    public double Price { get; set; }
    [JsonProperty("stockQuantity")]
    public long StockQuantity { get; set; }
    [JsonProperty("categoryId")]
    public string? CategoryId { get; set; }
    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

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

    public Product(string? name, string? description, double price, long stockQuantity, string categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
        CreatedDate = DateTime.Now;
    }

    public Product()
    {

    }

    public static implicit operator Product(Document data)
    {
        return new Product().ConvertTo<Product>(data);
    }
}

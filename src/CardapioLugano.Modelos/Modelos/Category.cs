using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class Category : BaseModel
{
    public static readonly string Categories = "categories";
    public Category()
    {

    }
    public Category(string? name)
    {
        Name = name;
    }

    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("products")]
    public List<Product?> Products { get; set; } = new();

    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "$id", Id },
            { "name", Name },
            {"products", Products },
        };
    }

    public static implicit operator Category(Document data)
    {
        return new Category().ConvertTo<Category>(data);
    }
}

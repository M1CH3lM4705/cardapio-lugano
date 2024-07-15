using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Models;
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

    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "name", Name }
        };
    }

    public static implicit operator Category(Document data)
    {
        return new Category().ConvertTo<Category>(data);
    }
}

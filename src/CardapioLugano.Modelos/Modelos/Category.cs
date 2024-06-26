using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class Category : BaseModel
{
    public static readonly string Categories = "categories";

    [JsonProperty("name")]
    public string? Name { get; set; }
    public override Category ConvertTo<Category>(Document data)
    {
        return JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(data.Data))!;
    }

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


using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public abstract class BaseModel
{
    [JsonProperty("$id")]
    public string? Id { get; set; }
    [JsonProperty("$createdAt")]
    public DateTime CreatedAt { get; set; }
    public abstract Dictionary<string, object?> ToMap();
    public virtual T ConvertTo<T>(Document data)
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data.Data))!;
    }

}


using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public abstract class BaseModel
{
    [JsonProperty("$id")]
    protected string? Id { get; set; }
    public abstract Dictionary<string, object?> ToMap();
    public abstract T ConvertTo<T>(Document data);

}

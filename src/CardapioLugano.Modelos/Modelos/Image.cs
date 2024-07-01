using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Modelos;
public class Image : BaseModel
{
    public static readonly string Images = "images";

    public Image()
    {
        
    }
    public Image(string? productId, string? fileId)
    {
        ProductId = productId;
        FileId = fileId;
    }

    [JsonProperty("productId")]
    public string? ProductId { get; set; }
    [JsonProperty("fileId")]
    public string? FileId { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }

    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "productId", ProductId },
            { "fileId", FileId },
            { "description", Description },
        };
    }

    public static implicit operator Image(Document data) =>
        new Image().ConvertTo<Image>(data);
}

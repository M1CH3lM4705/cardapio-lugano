using Appwrite.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CardapioLugano.Modelos.Modelos;
public class Image : BaseModel
{
    public static readonly string Images = "images";

    public Image()
    {
        
    }
    public Image(string? productId, Appwrite.Models.File file, string projectId)
    {
        ProductId = productId;
        FileId = file.Id;
        UrlImage = $"https://cloud.appwrite.io/v1/storage/buckets/{file.BucketId}/files/{FileId}/view?project={projectId}&mode=admin";
    }

    [JsonProperty("productId")]
    public string? ProductId { get; set; }
    [JsonProperty("fileId")]
    public string? FileId { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
    [JsonProperty("urlImage")]
    public string? UrlImage { get; set; }
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "productId", ProductId },
            { "fileId", FileId },
            { "description", Description },
            { "url", UrlImage },
        };
    }

    public static implicit operator Image(Document data) =>
        new Image().ConvertTo<Image>(data);
}

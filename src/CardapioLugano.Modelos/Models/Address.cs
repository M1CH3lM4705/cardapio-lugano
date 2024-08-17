
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Models;
public class Address : BaseModel
{
    public static readonly string Addresses = "address";
    public Address()
    {
        
    }

    public Address(string postalCode, string number, string city, string bairro, string street)
    {
        PostalCode = postalCode;
        Number = number;
        City = city;
        Bairro = bairro;
        Street = street;
    }

    [JsonProperty("postalCode")]
    public string? PostalCode { get; set; }
    [JsonProperty("number")]
    public string? Number { get; set; }
    [JsonProperty("city")]
    public string? City { get; set; }
    [JsonProperty("bairro")]
    public string? Bairro { get; set; }
    [JsonProperty("street")]
    public string? Street { get; set; }
    [JsonProperty("complement")]
    public string? Complement { get; set; }
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "postalCode", PostalCode },
            { "number", Number },
            { "city", City },
            { "bairro", Bairro },
            { "street", Street },
            { "complement", Complement },
        };
    }
}

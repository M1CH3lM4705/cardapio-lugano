
using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Models;
public class Customer : BaseModel
{
    public static readonly string Customers = "customers";

    public Customer()
    {
        
    }

    public Customer(string id)
    {
        Id = id;
    }

    [JsonProperty("firstName")]
    public string? Name { get; set; }
    [JsonProperty("lastName")]
    public string? LastName { get; set; }
    [JsonProperty("email")]
    public string? Email { get; set; }
    [JsonProperty("address")]
    public List<Address> Addresses { get; set; } = [];
    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            { "firstName", Name },
            { "lastName", LastName },
            { "email", Email },
            { "address", Addresses },
        };
    }

    public static implicit operator Customer(Document data) =>
        new Customer().ConvertTo<Customer>(data);
}

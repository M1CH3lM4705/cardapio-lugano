﻿using Appwrite.Models;
using Newtonsoft.Json;

namespace CardapioLugano.Modelos.Models;
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
    [JsonProperty("active")]
    public bool Active { get; set; } = true;

    [JsonProperty("categories")]
    public Category? Category { get; set; }
    [JsonProperty("images")]
    public List<Image?> Images { get; set; } = [];

    public override Dictionary<string, object?> ToMap()
    {
        return new Dictionary<string, object?>
        {
            {"name" , Name},
            {"description" , Description},
            {"price", Price},
            {"stockQuantity", StockQuantity},
            {"active" , Active},
            {"categories", Category},
            { "images", Images },
        };
    }

    public static readonly string Products = "products";

    public Product(string? name, string? description, double price, long stockQuantity, string categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        Category = new Category { Id = categoryId };
    }

    public Product()
    {

    }

    public static implicit operator Product(Document data)
    {
        return new Product().ConvertTo<Product>(data);
    }

    public void AddImage(Image image) =>
        Images.Add(image);
}

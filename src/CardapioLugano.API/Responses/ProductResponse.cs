using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Responses;

public record ProductResponse(string? Id, string? Name, string? Description, bool Active, CategoryResponse Category)
{
    public static implicit operator ProductResponse(Product product)
    {
        return new ProductResponse(product.Id, product.Name, product.Description, product.Active, product.Category!);
    }
}


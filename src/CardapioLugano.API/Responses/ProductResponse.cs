using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Responses;

public record ProductResponse(string? Id, string? Name, string? Description)
{
    public static implicit operator ProductResponse(Product product)
    {
        return new ProductResponse(product.Id, product.Name, product.Description);
    }
}

using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Responses;

public record CategoryResponse(string? Id, string? Name)
{
    public static implicit operator CategoryResponse(Category category)
    {
        return new CategoryResponse(category.Id, category.Name);
    }
}

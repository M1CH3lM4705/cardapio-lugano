using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Responses;

public record CartResponse(string? Id, string TotalAmount)
{
    public static implicit operator CartResponse(Cart cart)
    {
        return new(cart.Id, cart.TotalAmount!.Value.ToString("C"));
    }
}

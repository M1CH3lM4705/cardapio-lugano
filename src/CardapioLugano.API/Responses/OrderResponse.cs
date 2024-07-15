using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Responses;

public record OrderResponse(string? CustomeId, string? TotalAmount, string? Status)
{
    public static implicit operator OrderResponse(Order order)
    {
        return new(order.CustomerId, order.TotalAmount.ToString("C"), order.Status);
    }
}
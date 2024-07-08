using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.Core.Requests;

public record OrderItemRequest(
    [Required(ErrorMessage = "[{0}] é obrigatório.")] int Quantity,
    [Required] double UnitPrice,
    [Required] string OrderId,
    [Required] string ProductId);

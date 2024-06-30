using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.API.Requests;

public record OrderRequest(string? OrderId, string? CustomerId, [Required] double TotalAmount, string? Status);

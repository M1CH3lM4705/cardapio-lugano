using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.Core.Requests;

public record OrderRequest(string? OrderId, string? CustomerId, [Required] double TotalAmount, string? Status);

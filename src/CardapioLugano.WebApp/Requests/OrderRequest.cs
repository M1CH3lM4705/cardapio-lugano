using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.WebApp.Requests;

public record OrderRequest(string? OrderId, string? CustomerId, [Required] double TotalAmount, string? Status);

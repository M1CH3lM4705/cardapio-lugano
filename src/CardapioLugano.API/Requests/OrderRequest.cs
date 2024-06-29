using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.API.Requests;

public record OrderRequest(string? OrderId, string? CustomeId, [Required] double TotalAmount, string? Status);

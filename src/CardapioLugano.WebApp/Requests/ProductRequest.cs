using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.WebApp.Requests;

public record ProductRequest(
    string? Id,
    [Required] string Name,
    string Description,
    [Required] double Price,
    [Required] long StockQuantity,
    bool Active,
    [Required][StringLength(maximumLength: 20)] string CategoryId);

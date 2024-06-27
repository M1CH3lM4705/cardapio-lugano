using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.API.Requests;

public record ProductRequest(
    [Required]string Name, 
    string Description, 
    [Required]double Price, 
    [Required]long StockQuantity,
    [Required][StringLength(maximumLength:20)]string CategoryId);

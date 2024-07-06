using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.API.Requests;

public record LoginRequest([EmailAddress]string Email, [Required]string Password);

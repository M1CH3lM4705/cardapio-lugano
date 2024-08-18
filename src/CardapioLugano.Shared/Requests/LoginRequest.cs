using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.Shared.Requests;

public record LoginRequest([EmailAddress] string Email, [Required] string Password);

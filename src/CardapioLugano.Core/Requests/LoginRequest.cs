using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.Core.Requests;

public record LoginRequest([EmailAddress] string Email, [Required] string Password);

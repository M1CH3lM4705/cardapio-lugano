using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.WebApp.Requests;

public record LoginRequest(
    [Required(ErrorMessage = "Digite o nome do usuário")]
    [EmailAddress] string Email, 
    [Required] string Password);

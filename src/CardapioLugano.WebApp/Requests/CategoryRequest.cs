using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.WebApp.Requests;

public record CategoryRequest(string? Id, [Required] string Name);

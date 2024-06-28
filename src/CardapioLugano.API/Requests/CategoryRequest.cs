using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.API.Requests;

public record CategoryRequest(string? Id, [Required] string Name);

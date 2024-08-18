using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.Shared.Requests;

public record CategoryRequest(string? Id, [Required] string Name);

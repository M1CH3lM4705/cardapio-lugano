using System.ComponentModel.DataAnnotations;

namespace CardapioLugano.Core.Requests;

public record CategoryRequest(string? Id, [Required] string Name);

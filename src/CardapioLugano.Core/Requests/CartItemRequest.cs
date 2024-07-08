namespace CardapioLugano.Core.Requests;

public record CartItemRequest(string? ProductId, int Quantity, double UnitPrice, string? Name);

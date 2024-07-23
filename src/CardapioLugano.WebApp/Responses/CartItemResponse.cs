namespace CardapioLugano.WebApp.Responses;

public record CartItemResponse(string Id, string? ProductId, string Name, int Quantity, double UnitPrice);

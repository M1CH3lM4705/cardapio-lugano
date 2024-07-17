namespace CardapioLugano.WebApp.Requests;

public record CartItemRequest(string? ProductId, int Quantity, double UnitPrice, string? Name, string CartId);

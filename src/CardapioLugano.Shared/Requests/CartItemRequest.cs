namespace CardapioLugano.Shared.Requests;

public record CartItemRequest(string? Id, string? ProductId, int Quantity, double UnitPrice, string? Name, string CartId = "", string UrlImage = "");

namespace CardapioLugano.WebApp.Responses;

public record CartResponse(string? Id, string TotalAmount, List<CartItemResponse> CartItems, int TotalItems = 0);

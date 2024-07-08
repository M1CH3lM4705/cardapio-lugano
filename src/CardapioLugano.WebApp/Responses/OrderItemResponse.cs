namespace CardapioLugano.WebApp.Responses;

public record OrderItemResponse(int Quantity, double UnitPrice, OrderResponse Order, ProductResponse Product);


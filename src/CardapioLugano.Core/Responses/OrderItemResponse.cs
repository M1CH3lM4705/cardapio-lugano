﻿using CardapioLugano.Modelos.Models;

namespace CardapioLugano.Core.Responses;

public record OrderItemResponse(int Quantity, double UnitPrice, OrderResponse Order, ProductResponse Product)
{
    public static implicit operator OrderItemResponse(OrderItem orderItem)
    {
        return new(orderItem.Quantity, orderItem.UnitPrice, orderItem.Order!, orderItem.Product!);
    }
}

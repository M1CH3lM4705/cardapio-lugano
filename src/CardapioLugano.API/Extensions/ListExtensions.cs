using Appwrite.Models;
using CardapioLugano.API.Responses;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Extensions;

public static class ListExtensions
{
    public static List<ProductResponse> DocumentListToProductResponseList(this DocumentList documentList)
    {
        var products = documentList.Documents.Select<Document, Product>(x => x).ToList();

        return products.Select<Product, ProductResponse>(x => x).ToList();
    }


    public static List<CategoryResponse> DocumentListToCategoryResponseList(this DocumentList documentList)
    {
        var products = documentList.Documents.Select<Document, Category>(x => x).ToList();

        return products.Select<Category, CategoryResponse>(x => x).ToList();
    }

    public static List<OrderResponse> DocumentListToOrderResponseList(this DocumentList documentList)
    {
        var orders = documentList.Documents.Select<Document, Order>(x => x).ToList();

        return orders.Select<Order, OrderResponse>(x => x).ToList();
    }

    public static List<OrderItemResponse> DocumentListToOrderItemsResponseList(this DocumentList documentList)
    {
        var orderItem = documentList.Documents.Select<Document, OrderItem>(x => x).ToList();

        return orderItem.Select<OrderItem, OrderItemResponse>(x => x).ToList();
    }

    public static List<CartResponse> DocumentListToCartsResponseList(this DocumentList documentList)
    {
        var orderItem = documentList.Documents.Select<Document, Cart>(x => x).ToList();

        return orderItem.Select<Cart, CartResponse>(x => x).ToList();
    }
}

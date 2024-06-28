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
}

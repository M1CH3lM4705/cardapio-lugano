using Appwrite.Models;
using CardapioLugano.API.Responses;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Extensions;

public static class ListExtensions
{
    public static List<ProductResponse> DocumentListToResponseList(this DocumentList documentList)
    {
        var products = documentList.Documents.Select<Document, Product>(x => x).ToList();

        return products.Select<Product, ProductResponse>(x => x).ToList();
    }
}

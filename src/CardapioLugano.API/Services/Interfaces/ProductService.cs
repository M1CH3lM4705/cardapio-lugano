using CardapioLugano.API.Responses;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Services.Interfaces;

public class ProductService : IProductService
{
    private readonly IDal<Product> _dalProduct;
    private readonly IDal<Image> _dalImage;

    public ProductService(IDal<Product> dalProduct, IDal<Image> dalImage)
    {
        _dalProduct = dalProduct;
        _dalImage = dalImage;
    }

    public async Task<ProductResponse> GetProductAsync(string productId)
    {
        var product = (Product)await _dalProduct.GetDocument(productId);

        return product;
    }
}

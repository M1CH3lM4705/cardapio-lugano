using Appwrite;
using CardapioLugano.API.Responses;
using CardapioLugano.API.Utils;
using CardapioLugano.Data.Configurations;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Persistence.Products;
using CardapioLugano.Modelos.Modelos;
using Microsoft.Extensions.Options;

namespace CardapioLugano.API.Services.Interfaces;

public class ProductService : IProductService
{
    private readonly IDal<Product> _dalProduct;
    private readonly IDal<Image> _dalImage;
    private readonly string? projectId;

    public ProductService(IDal<Product> dalProduct, IDal<Image> dalImage, IOptions<AppwriteConfiguration> config)
    {
        _dalProduct = dalProduct;
        _dalImage = dalImage;
        projectId = config.Value.ProjectId;
    }

    public async Task<ProductResponse> GetProductAsync(string productId)
    {
        var product = (Product)await _dalProduct.GetDocument(productId);

        return product;
    }

    public async Task UploadProductImageAsync(string productId, IFormFile file)
    {
        var result = await _dalProduct.UploadFile(file.GetByteFile(), file.ContentType);

        var product = (Product)await _dalProduct.GetDocument(productId);

        var image = new Image(productId, result, projectId!);
        product.AddImage(image);

        await _dalProduct.UpdateDocument(productId, product);
    }
}

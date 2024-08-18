using Appwrite;
using CardapioLugano.API.Extensions;
using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.API.Utils;
using CardapioLugano.Data.Configurations;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using Microsoft.Extensions.Options;

namespace CardapioLugano.API.Services;

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

    public async Task<Response<ProductResponse>> CreateProductAsync(ProductRequest request)
    {

        try
        {
            var product = new Product(
                    request.Name,
                    request.Description,
                    request.Price,
                    request.StockQuantity,
                    request.CategoryId
                );

            var result = (Product)await _dalProduct.CreateDocument(product);

            return new Response<ProductResponse>(result);
        }
        catch (AppwriteException ex)
        {

            return new Response<ProductResponse>(null, 500, ex.Message);
        }

        

    }

    public async Task<PagedResponse<List<ProductResponse>?>> GetAll(List<Query>? queries = null, int page = 0, int pageSize = 25)
    {
        try
        {
            var list = queries?.Aggregate(Enumerable.Empty<string>(), (curr, item) => curr.Append(item.ToString()));
            
            var listadocuments = await _dalProduct.ListDocuments(list?.ToList());

            if (listadocuments is null or { Total: 0 })
                return new PagedResponse<List<ProductResponse>?>(null, 500, "Não foi possível consultar os produtos");

            var products = listadocuments.DocumentListToProductResponseList();

            return new PagedResponse<List<ProductResponse>?>(
                products,
                (int)listadocuments.Total,
                page,
                pageSize);
        }
        catch
        {

            return new PagedResponse<List<ProductResponse>?>(null, 500, "Não foi possível consultar os produtos");
        }
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

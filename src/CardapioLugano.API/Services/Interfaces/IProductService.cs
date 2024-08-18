using Appwrite;
using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface IProductService
{
    Task<PagedResponse<List<ProductResponse>?>> GetAll(List<Query>? queries = null, int page = 0, int pageSize = 25);
    Task<ProductResponse> GetProductAsync(string productId);
    Task UploadProductImageAsync(string productId, IFormFile file);
    Task<Response<ProductResponse>> CreateProductAsync(ProductRequest request);
}

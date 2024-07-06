﻿using CardapioLugano.API.Responses;

namespace CardapioLugano.API.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponse> GetProductAsync(string productId);
    Task UploadProductImageAsync(string productId, IFormFile file);
}
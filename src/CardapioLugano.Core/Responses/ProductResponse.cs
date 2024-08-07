﻿using CardapioLugano.Modelos.Models;

namespace CardapioLugano.Core.Responses;

public record ProductResponse(string? Id, string? Name, string? Description, double Price, bool Active, CategoryResponse Category, List<ImageResponse> Images)
{
    public static implicit operator ProductResponse(Product product)
    {
        return new ProductResponse(product.Id, product.Name, product.Description, product.Price, product.Active, product.Category!,
            product.Images.Select<Image, ImageResponse>(x => x).ToList()
            );
    }
}


namespace CardapioLugano.WebApp.Responses;

public record ProductResponse(
    string? Id,
    string? Name,
    string? Description,
    double Price,
    bool Active,
    CategoryResponse Category,
    List<ImageResponse> Images);


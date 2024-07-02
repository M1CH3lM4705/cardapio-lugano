using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Responses;

public record ImageResponse(string ImageString)
{
    public static implicit operator ImageResponse(Image image) =>
        new(image.UrlImage!);
}

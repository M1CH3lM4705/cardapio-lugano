using CardapioLugano.Modelos.Models;

namespace CardapioLugano.Core.Responses;

public record ImageResponse(string ImageString)
{
    public static implicit operator ImageResponse(Image image) =>
        new(image.UrlImage!);
}

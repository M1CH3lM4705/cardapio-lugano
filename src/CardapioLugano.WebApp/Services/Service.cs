using Microsoft.AspNetCore.Components.Forms;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CardapioLugano.WebApp.Services;

public abstract class Service
{
    private const string mediaType = "application/json";
    protected StringContent ObterConteudo(object dado)
    {
        return new StringContent(
            JsonSerializer.Serialize(dado),
            Encoding.UTF8,
            mediaType
            );
    }

    protected MultipartFormDataContent ContentForm(IBrowserFile file)
    {
        var content = new MultipartFormDataContent();

        content.Add(new StreamContent(file.OpenReadStream()), "file", file.Name);

        return content;
    }
    protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options)!;
    }

    protected bool TratarErrosResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest) return false;

        response.EnsureSuccessStatusCode();
        return true;
    }
}

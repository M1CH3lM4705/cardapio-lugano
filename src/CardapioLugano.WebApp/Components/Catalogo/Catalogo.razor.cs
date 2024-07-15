using CardapioLugano.WebApp.Responses;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components.Catalogo;

public class CatalogoComponent : ComponentBase 
{
    [Parameter]
    public List<ProductResponse> Products { get; set; } = [];
}

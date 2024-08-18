using CardapioLugano.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components.Catalogo;

public class CatalogoComponent : ComponentBase 
{
    [CascadingParameter]
    protected string Id { get; set; } = null!;

    [Parameter]
    public List<ProductResponse> Products { get; set; } = [];
}

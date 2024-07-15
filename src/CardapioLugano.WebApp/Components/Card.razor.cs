using CardapioLugano.WebApp.Responses;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components;

public class CardComponent : ComponentBase
{
    [Parameter]
    public ProductResponse Product { get; set; } = null!;
}

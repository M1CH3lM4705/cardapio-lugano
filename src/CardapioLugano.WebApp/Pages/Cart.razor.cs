using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Pages;

public class CartPage : ComponentBase
{
    #region Properties
    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected CartResponse? Cart;
    #endregion

    #region Services

    [Inject]
    CartService CartService { get; set; } = null!;
    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        Cart = await CartService.GetCartByIdAsync(Id);
    }

    #endregion
}

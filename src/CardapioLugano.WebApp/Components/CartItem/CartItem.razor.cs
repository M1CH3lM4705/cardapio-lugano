using CardapioLugano.WebApp.GlobalState;
using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components.CartItem;

public class CartItemComponent : ComponentBase
{
    #region Properties
    [Parameter]
    public CartItemResponse CartItem { get; set; } = null!;

    [Parameter]
    public EventCallback<CartItemResponse> DecreaseCart { get; set; }

    [Parameter]
    public EventCallback<CartItemResponse> IncreaseCart { get; set; }

    #endregion

    #region Services

    #endregion

    #region Methods

    

    #endregion
}

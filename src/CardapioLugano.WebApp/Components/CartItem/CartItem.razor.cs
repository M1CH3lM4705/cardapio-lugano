using CardapioLugano.WebApp.GlobalState;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components.CartItem;

public class CartItemComponent : ComponentBase
{
    #region Properties
    [Parameter]
    public CartItemResponse CartItem { get; set; } = null!;

    #endregion

    #region Services
    [Inject]
    CartState CartState { get; set; } = null!;

    [Inject]
    CartService CartService { get; set; } = null!;
    #endregion

    #region Methods

    protected async Task CartItemRemove(CartItemResponse cartItem)
    {
        if (cartItem is null) return;

        var req = new CartItemRequest(cartItem.Id,
                                    cartItem.ProductId, 
                                    cartItem.Quantity, 
                                    cartItem.UnitPrice, 
                                    cartItem.Name, 
                                    CartState.Cart!);

        await CartService.RemoveCartAsync(req);

    }

    #endregion
}

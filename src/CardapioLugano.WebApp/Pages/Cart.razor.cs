using CardapioLugano.WebApp.Requests;
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

    protected async Task CartItemRemove(CartItemResponse cartItem)
    {
        if (cartItem is null) return;

        var req = new CartItemRequest(cartItem.Id,
                                    cartItem.ProductId,
                                    cartItem.Quantity,
                                    cartItem.UnitPrice,
                                    cartItem.Name,
                                    Cart!.Id!);


        if(cartItem.Quantity > 1)
            cartItem.Quantity--;

        await CartService.RemoveCartAsync(req);

        if (cartItem.Quantity == 1)
            Cart!.CartItems.Remove(Cart.CartItems.FirstOrDefault(x => x.Id == cartItem.Id)!);
    }

    protected async Task CartItemAdd(CartItemResponse cartItem)
    {
        if (cartItem is null) return;

        var req = new CartItemRequest(cartItem.Id,
                                    cartItem.ProductId,
                                    cartItem.Quantity,
                                    cartItem.UnitPrice,
                                    cartItem.Name,
                                    Cart!.Id!);


        if (cartItem.Quantity >= 1)
            cartItem.Quantity++;

        await CartService.AddItemCartAsync(req);

    }

    #endregion
}

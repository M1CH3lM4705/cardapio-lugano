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

    protected CartResponse? Cart { get; set; } = null;

    protected bool IsBusy { get; set; } = false;
    #endregion

    #region Services

    [Inject]
    CartService CartService { get; set; } = null!;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        var result = await CartService.GetCartByIdAsync(Id);

        Cart = result!.Data;

        IsBusy = false;
    }

    protected async Task CartItemRemove(CartItemResponse cartItem)
    {
        if (cartItem is null) return;

        var quantity = cartItem.Quantity;
        quantity--;

        var req = new CartItemRequest(cartItem.Id,
                                    cartItem.ProductId,
                                    cartItem.Quantity,
                                    cartItem.UnitPrice,
                                    cartItem.Name,
                                    Cart!.Id!,
                                    cartItem.UrlImage);


        if(cartItem.Quantity > 1)
            cartItem.RemoveOneQuantity();

        await CartService.RemoveCartAsync(req);

        if (cartItem.Quantity == 1 && quantity == 0)
            Cart!.CartItems.Remove(Cart.CartItems.FirstOrDefault(x => x.Id == cartItem.Id)!);

        Cart.UpdateCart();
    }

    protected async Task CartItemAdd(CartItemResponse cartItem)
    {
        if (cartItem is null) return;

        var req = new CartItemRequest(cartItem.Id,
                                    cartItem.ProductId,
                                    cartItem.Quantity,
                                    cartItem.UnitPrice,
                                    cartItem.Name,
                                    Cart!.Id!,
                                    cartItem.UrlImage);


        if (cartItem.Quantity >= 1)
            cartItem.AddOneQuantity();

        await CartService.AddItemCartAsync(req);

        Cart.UpdateCart();
    }

    #endregion
}

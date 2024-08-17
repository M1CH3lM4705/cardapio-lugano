using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using CardapioLugano.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Components;

public class CardComponent : ComponentBase
{
    #region Properties
    [CascadingParameter]
    protected string Id { get; set; } = string.Empty;

    [Parameter]
    public ProductResponse Product { get; set; } = null!;

    protected bool IsBusy { get; set; } = false;
    #endregion

    #region Services
    [Inject]
    private CartService CartService { get; set; } = null!;

    [Inject]
    protected ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    protected IPublisher Publisher { get; set; } = null!;
    #endregion

    #region Methods

    protected async Task AddItemCart(string id)
    {
        var image = Product.Images.First().ImageString;
        IsBusy = true;
        var request = new CartItemRequest(string.Empty, Product.Id, (int)Product.StockQuantity, Product.Price, Product.Name, id, image);

        await CartService.AddItemCartAsync(request);

        Publisher.HasChanged(id);

        IsBusy = false;
    }

    #endregion
}

using CardapioLugano.WebApp.Services;
using CardapioLugano.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components.Footer;

public class FooterComponent : ComponentBase, IDisposable
{
    #region Properties
    protected int CountCart {  get; set; } = 0;
    protected string? Id { get; set; }
    #endregion

    #region Services
    [Inject]
    private IPublisher Publisher { get; set; } = null!;

    [Inject]
    private CartService CartService { get; set; } = null!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Methods
    protected override void OnInitialized()
    {
        Publisher.OnHasChanged += ChangedCart;
        Publisher.OnHasChanged += AddIdCart;
    }

    protected void GoToCart()
    {
        NavigationManager.NavigateTo($"/carrinho/{Id}");
    }

    private void ChangedCart(string id)
    {
        if(!string.IsNullOrEmpty(id))
        {
            Task.Factory.StartNew(async () =>
            {

                var result = await CartService.GetCartByIdAsync(id);
                CountCart = result!.Data!.TotalItems;
                StateHasChanged();
            });

        }
    }

    private void AddIdCart(string id) =>
        Id = id;

    public void Dispose()
    {
        Publisher.OnHasChanged -= ChangedCart;
        Publisher.OnHasChanged -= AddIdCart;
    }
    #endregion
}

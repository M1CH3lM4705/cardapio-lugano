using CardapioLugano.WebApp.Services;
using CardapioLugano.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Components.Footer;

public class FooterComponent : ComponentBase
{
    #region Properties
    protected int CountCart {  get; set; } = 0;
    #endregion

    #region Services
    [Inject]
    private IPublisher Publisher { get; set; } = null!;

    [Inject]
    private CartService CartService { get; set; } = null!;

    #endregion

    #region Methods
    protected override void OnInitialized()
    {
        Publisher.OnHasChanged += ChangedCart;
    }

    private void ChangedCart(string id)
    {
        if(!string.IsNullOrEmpty(id))
        {
            Task.Factory.StartNew(async () =>
            {

                var result = await CartService.GetCartByIdAsync(id);
                CountCart = result!.CartItems.Count;
                StateHasChanged();
            });

        }
    }
    #endregion
}

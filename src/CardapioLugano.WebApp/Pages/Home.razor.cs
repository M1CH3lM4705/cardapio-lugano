using CardapioLugano.WebApp.GlobalState;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using CardapioLugano.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Pages;

public class HomePage : ComponentBase
{
    #region Properties
    protected bool IsBusy { get; set; } = false;
    protected List<ProductResponse> Products { get; set; } = [];
    protected string Id { get; set; } = string.Empty;

    [CascadingParameter]
    protected string CartId { get; set; } = string.Empty;
    #endregion

    #region Services
    [Inject]
    protected ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    protected ProductService Handler { get; set; } = null!;

    [Inject]
    protected CartService CartService { get; set; } = null!;

    [Inject]
    IPublisher Publisher { get; set; } = null!;

    [Inject]
    public CartState CartState { get; set; } = null!;
    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        Id = DateTime.Now.ToString();
        try
        {
            if (string.IsNullOrEmpty(CartState.Cart))
            {
                CartState.Cart = await CartService.CreateCartAsync(new CartRequest(Id));                
            }

            Publisher.HasChanged(CartState.Cart);

            var result = await Handler.GetAllAsync();

            if (result.IsSuccess)
                Products = result.Data ?? [];
        }
        catch (Exception ex)
        {

            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}

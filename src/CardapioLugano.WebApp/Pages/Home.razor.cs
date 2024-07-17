using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
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

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        Id = DateTime.Now.ToString();
        try
        {
            CartId = await CartService.CreateCartAsync(new CartRequest(Id));

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

using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Pages.Admin.Catalogo;

public class CatalogoPage : ComponentBase
{
    #region Properties
    protected bool IsBusy { get; set; } = false;
    protected List<ProductResponse> Products { get; set; } = [];
    #endregion

    #region Services
    [Inject]
    protected ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    protected ProductService Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
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

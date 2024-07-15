using CardapioLugano.WebApp.Components.Shared;
using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Pages.Admin.Catalogo;

public class CatalogoPage : ComponentBase
{
    #region Properties
    protected bool IsBusy { get; set; } = false;

    private int totalItens;

    protected string rowsPorPerString = "Linhas por página:";
    protected IEnumerable<ProductResponse> Products { get; set; } = [];
    protected MudTable<ProductResponse> ProductsTable { get; set; } = null!;
    #endregion

    #region Services
    [Inject]
    protected ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    protected ProductService Handler { get; set; } = null!;

    [Inject]
    private IDialogService _dialogService { get; set; } = null!;

    [Inject]
    private ProductService _productService { get; set; } = null!;
    #endregion

    #region Overrides

    protected async Task<TableData<ProductResponse>> ServerReload(TableState state, CancellationToken token)
    {
        IsBusy = true;

        try
        {
            var result = await Handler.GetAllAsync();
            await Task.Delay(300, token);

            if (result.IsSuccess)
            {
                Products = result.Data!.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray() ?? [];
                totalItens = result.TotalCount;                
            }

        }
        catch (Exception ex)
        {

            Snackbar.Add(ex.Message, Severity.Error);
            return new TableData<ProductResponse> { TotalItems = 0, Items = null };
        }
        finally
        {
            IsBusy = false;
        }
        return new TableData<ProductResponse> { TotalItems = totalItens, Items = Products };
    }

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

    #region Metodos

    protected async Task EditShowDialog(ProductResponse productResponse)
    {
        var parameters = new DialogParameters<FormDialog> { { x => x.ProductResponse, productResponse } };

        var dialog = await _dialogService.ShowAsync<FormDialog>("Edit Server", parameters);

        var result = await dialog.Result;

        if (!result!.Canceled)
        {
            await Edit((ProductRequest)result.Data);
        }
    }
    protected async Task ConfirmDelete(string id)
    {
        var options = new DialogOptions
        {
            Position = DialogPosition.BottomCenter
        };

        bool? result = await _dialogService.ShowMessageBox(
            "Confirma a exclusão",
            "A exclusão não pode ser desfeita!",
            yesText: "Deleta", cancelText: "Cancela",
            options:options
            ); ;

        if(result ?? false)
        {
            await Delete(id);
        }
    }

    private async Task Delete(string id)
    {
        var result = await _productService.DeleteAsync(id);

        if (result)
        {
            Snackbar.Add("Item removido", Severity.Success);
        }
        else
        {
            Snackbar.Add("Ocorre um erro ao remover o item", Severity.Error);
        }
    }

    private async Task Edit(ProductRequest request)
    {
  
        await _productService.UpdateAsync(request);
        await ProductsTable.ReloadServerData();
    }

    #endregion
}

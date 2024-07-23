using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Components.Shared;

public class FormDialogComponent : ComponentBase
{
    #region Properties

    protected string? productName;
    protected string? description;
    protected double price;
    protected int stockQuantity;
    protected string? categoryId;
    protected bool Active { get; set; } = true;
    protected string? fileImage;

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = null!;

    [Parameter]
    public ProductResponse ProductResponse { get; set; } = null!;


    #endregion

    #region Services

    [Inject]
    protected ISnackbar Snackbar { get; set; } = null!;

    #endregion


    #region metodos

    protected override void OnInitialized()
    {
        productName = ProductResponse.Name;
        description = ProductResponse.Description;
        price = ProductResponse.Price;
        stockQuantity = (int)ProductResponse.StockQuantity;
        categoryId = ProductResponse.Category.Id;
        Active = ProductResponse.Active;
    }
    protected void Cancel() => MudDialog?.Cancel();

    protected void Edit()
    {
        var productResponse = new ProductRequest(ProductResponse.Id, productName!, description!,
            price,
            stockQuantity,
            Active,
            categoryId!);

        MudDialog?.Close(DialogResult.Ok(productResponse));
        Snackbar.Add("Item Atualizado", Severity.Success);
    }

    #endregion
}

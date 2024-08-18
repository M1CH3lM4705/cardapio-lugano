using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace CardapioLugano.WebApp.Pages.Admin.Produtos;

public class CreateProductForm : ComponentBase
{
    #region Injects
    [Inject] protected CategoryService Service { get; set; } = null!;

    [Inject] protected ProductService ProductService { get; set; } = null!;
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] ISnackbar Snackbar { get; set; } = null!;
    #endregion

    #region Properties
    protected string? productName;
    protected string? description;
    protected double price;
    protected int stockQuantity;
    protected string? fileImage;
    protected IBrowserFile? imageByte;

    protected ICollection<CategoryResponse>? categories;

    protected CategoryResponse? Category;
    #endregion

    #region Services

    protected override async Task OnInitializedAsync()
    {
        var result = await Service.GetAllCategoriesAsync();

        categories = result.Data;
    }

    protected void CategorySelected(CategoryResponse category) =>
        Category = category;

    protected async Task Save()
    {
        var request = new ProductRequest("",productName!, description!, price, stockQuantity, true, Category!.Id!);

        var result = await ProductService.CreateProduct(request);

        if (result.IsSuccess)
            await ProductService.UploadFileAsync(result.Data!.Id!, imageByte!);
        else
        {
            Snackbar.Add(result.Message, Severity.Error);
            return;
        }

        NavigationManager.NavigateTo("/Admin/Catalogo");
    }

    protected Func<CategoryResponse, string> converter = a => a!.Name!;

    protected async Task UploadFile(IBrowserFile file)
    {
        var resizeImage = await file.RequestImageFileAsync(file.ContentType, 200, 200);

        using var fileStream = resizeImage.OpenReadStream();
        using var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream);

        imageByte = file;

        var imageUpload = Convert.ToBase64String(memoryStream.ToArray());

        fileImage = $"data:{file.ContentType};base64,{imageUpload}";

        
    }
    #endregion
}

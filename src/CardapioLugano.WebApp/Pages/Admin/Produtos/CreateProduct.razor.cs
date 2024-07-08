using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Responses;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CardapioLugano.WebApp.Pages.Admin.Produtos;

public class CreateProductForm : ComponentBase
{
    #region Injects
    [Inject] protected ProductService Service { get; set; } = null!;
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    #endregion

    #region Properties
    protected string productName;
    protected string description;
    protected double price;
    protected int stockQuantity;
    protected string? fileImage;

    protected ICollection<CategoryResponse>? categories;

    protected CategoryResponse? Category;
    #endregion

    #region Services

    protected override async Task OnInitializedAsync()
    {
        categories = await Service.GetAllCategoriesAsync();
    }

    protected void CategorySelected(CategoryResponse category) =>
        Category = category;

    protected async Task Save()
    {
        var request = new ProductRequest(productName, description, price, stockQuantity, Category!.Id!);

        await Service.CreateProduct(request);

        NavigationManager.NavigateTo("/Admin/Catalogo");
    }

    protected Func<CategoryResponse, string> convert = a => a!.Name!;

    protected async Task UploadFile(IBrowserFile file)
    {
        var resizeImage = await file.RequestImageFileAsync(file.ContentType, 200, 200);

        using var fileStream = resizeImage.OpenReadStream();
        using var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream);

        var imageUpload = Convert.ToBase64String(memoryStream.ToArray());

        fileImage = $"data:{file.ContentType};base64,{imageUpload}";

        
    }
    #endregion
}

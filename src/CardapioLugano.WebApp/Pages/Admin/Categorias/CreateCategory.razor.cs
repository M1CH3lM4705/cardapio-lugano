using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Pages.Admin.Categorias;

public class CreateCategoryForm : ComponentBase
{
    #region Properties

    protected string? CategoryName;

    #endregion

    #region Services

    [Inject]
    private CategoryService _categoryService { get; set; } = null!;

    [Inject]
    private ISnackbar _snacbar { get; set; } = null!;

    #endregion

    #region Metodos

    protected async Task Save()
    {
        var request = new CategoryRequest("", CategoryName!);

        await _categoryService.CreateCategoryAsync(request);
    }

    #endregion
}

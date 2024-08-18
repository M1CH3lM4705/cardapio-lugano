using CardapioLugano.Shared.Requests;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Pages.Admin.Autenticacao;

public class LoginPage : ComponentBase
{
    #region Services
    [Inject] AuthService AuthApi { get; set; } = null!;
    [Inject] NavigationManager NavigationManager { get; set; } = null!;

    [Inject] ISnackbar Snackbar { get; set; } = null!;
    #endregion

    #region Properties
    protected string? email;
    protected string? senha;
    protected bool IsBusy { get; set; } = false;
    #endregion 

    [SupplyParameterFromQuery]
    public string? ReturnUrl { get; set; }
    protected async Task FazerLogin()
    {
        IsBusy = true;

        try
        {

            var req = new LoginRequest(email!, senha!);
            var result = await AuthApi.LoginAsync(req);

            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo(ReturnUrl ?? "/admin/dashboard");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
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
}

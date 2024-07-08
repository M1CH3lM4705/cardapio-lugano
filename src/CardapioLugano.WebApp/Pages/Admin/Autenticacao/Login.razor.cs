using CardapioLugano.WebApp.Requests;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace CardapioLugano.WebApp.Pages.Admin.Autenticacao;

public class LoginPage : ComponentBase
{
    [Inject] ProductService AuthApi { get; set; } = null!;
    [Inject] NavigationManager NavigationManager { get; set; } = null!;

    protected string email;
    protected string senha;

    [SupplyParameterFromQuery]
    public string? ReturnUrl { get; set; }
    protected async Task FazerLogin()
    {
        var req = new LoginRequest(email, senha);
        var resposta = await AuthApi.LoginAsync(req);

        if (resposta.IsSuccess && ReturnUrl is not null)
        {
            NavigationManager.NavigateTo(ReturnUrl);
        }
    }
}

using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Components.Shared;

public class DialogCheckoutComponent : ComponentBase
{
    #region Properties
    [Parameter]
    public bool OpenDrawer { get; set; } = false;

    protected MudTabs? Tabs;
    protected MudTabPanel? Delivery;
    protected MudTabPanel? PickUpInStore;

    protected string? firstName;
    protected string? phone;
    protected string? street;
    protected string? bairro;
    protected string? complement;
    protected int number;
    #endregion

    #region Methods

    protected void Activate(MudTabPanel panel) =>
        Tabs!.ActivatePanel(panel);

    #endregion
}

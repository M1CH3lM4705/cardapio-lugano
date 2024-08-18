using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Components.Shared;

public class DialogCheckoutComponent : ComponentBase
{
    #region Properties
    [Parameter]
    public bool OpenDrawer { get; set; }
    protected MudTabs? Tabs;
    protected MudTabPanel? Delivery;
    protected MudTabPanel? PickUpInStore;
    #endregion

    #region Methods

    protected void Activate(MudTabPanel panel) =>
        Tabs!.ActivatePanel(panel);

    #endregion
}

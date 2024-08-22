using CardapioLugano.Modelos.Models;
using CardapioLugano.WebApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CardapioLugano.WebApp.Components.Shared;

public class DialogCheckoutComponent : ComponentBase
{
    #region Properties

    protected MudTabs? Tabs;
    protected MudTabPanel? Delivery;
    protected MudTabPanel? PickUpInStore;

    [Parameter]
    public ICollection<Neighborhood> Neighborhoods { get; set; } = null!;

    protected Neighborhood? Neighborhood;

    protected string? firstName;
    protected string? phone;
    protected string? street;
    protected string? bairro;
    protected string? complement;
    protected int number;
    #endregion

    #region Services

    #endregion

    #region Methods

    protected void Activate(MudTabPanel panel) =>
        Tabs!.ActivatePanel(panel);

    protected Func<Neighborhood, string> Converter = a => a.Nome!;

    protected void NeighborhoodSelect(Neighborhood neighborhood) =>
        Neighborhood = neighborhood;

    #endregion
}

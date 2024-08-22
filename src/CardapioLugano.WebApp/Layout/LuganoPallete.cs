using MudBlazor;
using MudBlazor.Utilities;

namespace CardapioLugano.WebApp.Layout;

public class LuganoPallete : PaletteLight
{
    public MudColor BtPrimary { get; set; }
    private LuganoPallete()
    {
        Primary = new MudColor("#4E342E");
        Secondary = new MudColor("#8D6E63");
        Tertiary = new MudColor("#D7CCC8");
        Background = new MudColor("#FFF3E0");
        BtPrimary = new("#795548");
    }

    public static LuganoPallete CreatePallete => new();
}

using MudBlazor;
using MudBlazor.Utilities;

namespace CardapioLugano.WebApp.Layout;

public class LuganoPallete : PaletteDark
{
    private LuganoPallete()
    {
        Primary = new MudColor("rgba(173,173,177,1)");
        Secondary = new MudColor("#F6AD31");
        Tertiary = new MudColor("#8AE491");
    }

    public static LuganoPallete CreatePallete => new();
}

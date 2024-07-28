using MudBlazor;
using MudBlazor.Utilities;

namespace CardapioLugano.WebApp.Layout;

public class LuganoPallete : PaletteDark
{
    private LuganoPallete()
    {
        Primary = new MudColor("#4E342E");
        Secondary = new MudColor("#8D6E63");
        Tertiary = new MudColor("#D7CCC8");
    }

    public static LuganoPallete CreatePallete => new();
}

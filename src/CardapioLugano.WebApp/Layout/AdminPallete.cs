using MudBlazor;
using MudBlazor.Utilities;

namespace CardapioLugano.WebApp.Layout;

public class AdminPallete : PaletteDark
{
    private AdminPallete()
    {
        Primary = new MudColor("#9966FF");
        Secondary = new MudColor("#F6AD31");
        Tertiary = new MudColor("#8AE491");
    }

    public static AdminPallete CreatePallete => new();
}

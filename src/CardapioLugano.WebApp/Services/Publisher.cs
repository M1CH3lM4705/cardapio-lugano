using CardapioLugano.WebApp.Services.Interfaces;

namespace CardapioLugano.WebApp.Services;

public class Publisher : IPublisher
{
    public event Action<string>? OnHasChanged;

    public void HasChanged(string id)
    {
        OnHasChanged!.Invoke(id);
    }
}

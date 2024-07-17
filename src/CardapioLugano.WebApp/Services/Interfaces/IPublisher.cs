namespace CardapioLugano.WebApp.Services.Interfaces;

public interface IPublisher
{
    event Action<string> OnHasChanged;
    void HasChanged(string id);
}

using Appwrite;
using Appwrite.Services;
using CardapioLugano.Data.Persistence.Interfaces;

namespace CardapioLugano.Data.Persistence;
public class AppwriteBase : IAppwriteBase
{
    private readonly Client _client;
    public AppwriteBase(Client client)
    {
        _client = client;

        Databases = new Databases(_client);
    }
    public Databases Databases {  get; }
}

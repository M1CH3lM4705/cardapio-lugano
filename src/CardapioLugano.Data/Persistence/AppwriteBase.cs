using Appwrite;
using Appwrite.Services;
using CardapioLugano.Data.Configurations;
using CardapioLugano.Data.Persistence.Interfaces;
using Microsoft.Extensions.Options;

namespace CardapioLugano.Data.Persistence;
public class AppwriteBase : IAppwriteBase
{

    public AppwriteBase(IOptions<AppwriteConfiguration> appwrite)
    {
        var client = new Client()
            .SetEndpoint(appwrite.Value.Endpoint!)
            .SetProject(appwrite.Value.ProjectId!)
            .SetKey(appwrite.Value.ApiKey!);

        Databases = new Databases(client);
        Storage = new Storage(client);
        Account = new Account(client);
        Users = new Users(client);

        Id = appwrite.Value.DatabaseId!;
        BucketId = appwrite.Value.StorageId!;
    }
    public Databases Databases {  get; }
    public Storage Storage { get; }
    public Account Account { get; }
    public Users Users { get; }

    public string? Id {  get; }


    public string? BucketId { get; }
}

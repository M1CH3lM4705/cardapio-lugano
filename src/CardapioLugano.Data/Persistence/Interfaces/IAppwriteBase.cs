using Appwrite.Services;

namespace CardapioLugano.Data.Persistence.Interfaces;
public interface IAppwriteBase
{
    Databases Databases { get; }
    Storage Storage { get; }
    Account Account { get; }
    Users Users { get; }
    string? Id { get; }
    string? BucketId { get; }
}

using Appwrite.Services;

namespace CardapioLugano.Data.Persistence.Interfaces;
public interface IAppwriteBase
{
    Databases Databases { get; }
    Storage Storage { get; }
    string? Id { get; }
    string? BucketId { get; }
}

using Appwrite.Services;

namespace CardapioLugano.Data.Persistence;
internal interface IAppwriteBase
{
    Databases Databases { get; }
}

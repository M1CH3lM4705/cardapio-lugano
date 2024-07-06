using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.Data.Persistence.Products;
public class DAL<T> : IDal<T> where T : BaseModel
{
    private readonly string collectionId;
    private readonly Databases _databases;
    private readonly Storage _storage;
    private readonly Account _account;
    private readonly string databaseId;
    private readonly string storageId;
    public DAL(string collectionId, IAppwriteBase appwriteBase)
    {
        this.collectionId = collectionId;
        _databases = appwriteBase.Databases;
        databaseId = appwriteBase.Id!;
        storageId = appwriteBase.BucketId!;
        _storage = appwriteBase.Storage;
        _account = appwriteBase.Account;
    }

    public async Task<DocumentList> ListDocuments(List<string>? queries = null)
    {
        DocumentList result = await _databases.ListDocuments(
            databaseId: databaseId,
            collectionId: collectionId,
            queries: queries // optional
        );

        return result;
    }

    public async Task<Document> CreateDocument(T data)
    {

        Document result = await _databases.CreateDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: ID.Unique(),
            data: data.ToMap()
            );

        return result;
    }

    public async Task<Document> GetDocument(string id, List<string>? queries = null)
    {
        Document result = await _databases.GetDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: id,
            queries: queries // optional
        );

        return result;
    }

    public async Task<Document> UpdateDocument(string id, T data)
    {
        Document result = await _databases.UpdateDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: id,
            data: data.ToMap()
            );

        return result;
    }

    public async Task<bool> DeleteDocument(string id)
    {

        try
        {
            await _databases.DeleteDocument(
                databaseId: databaseId,
                collectionId: collectionId,
                documentId: id);

            return true;
        }
        catch
        {

            return false;
        }
    }

    public async Task<Appwrite.Models.File> UploadFile(byte[] fileByte, string mimeType)
    {
        var permission = new List<string>
        {
            Permission.Read(Role.Any()), Permission.Write(Role.Any())
        };

        var result = await _storage.CreateFile(
                bucketId: storageId,
                fileId: ID.Unique(),
                file: InputFile.FromBytes(fileByte, ID.Unique(), mimeType),
                permissions: permission
            );

        return result;
    }

    public async Task<byte[]> GetFileView(string id)
    {
        return await _storage.GetFileView(bucketId:storageId, id);   
    }

    public async Task<Session> Login(string username, string password)
    {
        var session = await _account.CreateEmailPasswordSession(username, password);

        return session;
    }
}

using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.Data.Persistence.Products;
public class DAL<T> where T : BaseModel
{
    private readonly string collectionId;
    private readonly Databases _databases;
    private readonly string databaseId;
    public DAL(string collectionId, IAppwriteBase appwriteBase)
    {
        this.collectionId = collectionId;
        _databases = appwriteBase.Databases;
        databaseId = appwriteBase.Id;
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
            data: data
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
            data: data
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
}

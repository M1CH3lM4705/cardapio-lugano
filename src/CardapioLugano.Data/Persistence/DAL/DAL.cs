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
        var result = appwriteBase.Databases.List().Result;
        databaseId = result.Databases.First().Id;
    }

    public async Task<DocumentList> ListDocuments(string collectionId)
    {
        DocumentList result = await _databases.ListDocuments(
            databaseId: databaseId,
            collectionId: collectionId,
            queries: new List<string>() // optional
        );

        return result;
    }

    public async Task<Document> CreateDocument(Dictionary<string, object> data)
    {
        Document result = await _databases.CreateDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: ID.Unique(),
            data: data
            );
        
        return result;
    }

    public async Task<Document> GetDocument(string id, List<string>? queries)
    {
        Document result = await _databases.GetDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: id,
            queries: queries // optional
        );

        return result;
    }

    public async Task<Document> UpdateDocument(string id, Dictionary<string, object> data)
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

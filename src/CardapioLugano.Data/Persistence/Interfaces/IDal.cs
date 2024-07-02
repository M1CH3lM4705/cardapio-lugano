using Appwrite.Models;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.Data.Persistence.Interfaces;
public interface IDal<T> where T : BaseModel
{
    Task<DocumentList> ListDocuments(List<string>? queries = null);
    Task<Document> CreateDocument(T data);
    Task<Document> GetDocument(string id, List<string>? queries = null);
    Task<Document> UpdateDocument(string id, T data);
    Task<bool> DeleteDocument(string id);
    Task<Appwrite.Models.File> UploadFile(byte[] fileByte, string mimeType);
    Task<byte[]> GetFileView(string id);
}

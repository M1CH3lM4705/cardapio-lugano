using Appwrite.Models;

namespace CardapioLugano.Data.Token;
public interface ITokenGenerator
{
    string GenerateToken(Session session);
}

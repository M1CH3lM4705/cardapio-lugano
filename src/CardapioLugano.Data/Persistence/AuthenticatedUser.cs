using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CardapioLugano.Data.Persistence;
public class AuthenticatedUser(IHttpContextAccessor contextAccessor)
{
    public string Session => GetClaims().FirstOrDefault(x => x.Type == ClaimTypes.UserData)?.Value!;

    public IEnumerable<Claim> GetClaims() =>
        contextAccessor.HttpContext!.User.Claims;
}

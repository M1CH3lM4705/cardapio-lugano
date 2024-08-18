using CardapioLugano.Shared.Requests;
using CardapioLugano.Shared.Responses;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Data.Token;
using CardapioLugano.Modelos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioLugano.API.Endpoints;

public static class AuthExtensions
{
    public static void MapEndopointAuthentication(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("auth").WithTags("Authentication");

        groupBuilder.MapPost("login", async (
            [FromServices]IDal<Product> dal,
            [FromServices]ITokenGenerator token,
            LoginRequest login) =>
        {
            var session = await dal.Login(login.Email, login.Password);

            var tk = token.GenerateToken(session);

            //var user = await dal.GetUser(session.UserId);

            var result = new LoginResponse(tk, "", session.ProviderUid);

            var response = new Response<LoginResponse>(result);
            return Results.Ok(response);
        });
    }
}

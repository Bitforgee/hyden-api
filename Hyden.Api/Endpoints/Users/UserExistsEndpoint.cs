using Hyden.Api.Common.Api;
using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Users;

public class UserExistsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/exists/{email}", HandleAsync)
            .WithName("Users: Exists")
            .WithSummary("Verifica se um usuário existe pelo e-mail fornecido.")
            .WithDescription("Retorna 200 se o usuário existir e 404 se não existir.")
            .WithOrder(6)
            .Produces<Response<bool>>(StatusCodes.Status200OK)
            .Produces<Response<bool>>(StatusCodes.Status404NotFound)
            .Produces<Response<bool>>(StatusCodes.Status500InternalServerError)
            .AllowAnonymous();

    private static async Task<IResult> HandleAsync(
        IUserHandler handler,
        string email)
    {
        var request = new UserExistsRequest { Email = email };

        var result = await handler.UserExistsAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.NotFound();
    }
}

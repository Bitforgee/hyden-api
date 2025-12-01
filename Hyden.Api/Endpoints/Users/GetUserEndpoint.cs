using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Users;

public class GetUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{UserId:guid}", HandleAsync)
            .WithName("Users: Get by ID")
            .WithSummary("Obtém informações de um usuário")
            .WithDescription("Retorna os dados de um usuário específico pelo ID")
            .WithOrder(5)
            .Produces<Response<User>>(StatusCodes.Status200OK)
            .Produces<Response<User>>(StatusCodes.Status401Unauthorized)
            .Produces<Response<User>>(StatusCodes.Status404NotFound)
            .Produces<Response<User>>(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        IUserHandler handler,
        [AsParameters] GetUserRequest request)
    {
        var result = await handler.GetUser(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.NotFound(result.Message);
    }
}
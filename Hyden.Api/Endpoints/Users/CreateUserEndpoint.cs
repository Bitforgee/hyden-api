using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;
using System.Security.Claims;

namespace Hyden.Api.Endpoints.Users;

public class CreateUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapPost("/", HandleAsync)
       .WithName("Users: Create")
       .WithSummary("Cria uma novo usuário")
       .WithDescription("Cria uma novo usuário")
       .WithOrder(1)
       .Produces<Response<User?>>()
       .AllowAnonymous();


    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IUserHandler handler,
        CreateUserRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Message);
    }
}

using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;
using System.Security.Claims;

namespace Hyden.Api.Endpoints.Users;

public class UpdateUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/", HandleAsync)
             .WithName("Users: Update")
             .WithSummary("Atualiza os dados do usuário")
             .WithDescription("Atualiza os dados do usuário")
             .WithOrder(1)
             .Produces<Response<User?>>()
             .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        IUserHandler handler,
        UpdateUserRequest request)
    {
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Message);
    }
}

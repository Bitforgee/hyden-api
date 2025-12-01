using Hyden.Api.Common.Api;
using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Users;

public class LoginUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/login", HandleAsync)
            .WithName("Auth: Login")
            .WithSummary("Autentica um usuário e retorna um JWT token")
            .WithDescription("Realiza login com email e senha, retornando um token JWT Bearer")
            .WithOrder(2)
            .Produces<Response<AuthResponseDto>>(StatusCodes.Status200OK)
            .Produces<Response<AuthResponseDto>>(StatusCodes.Status401Unauthorized)
            .Produces<Response<AuthResponseDto>>(StatusCodes.Status500InternalServerError)
            .AllowAnonymous();

    private static async Task<IResult> HandleAsync(
        IAuthHandler handler,
        LoginUserRequest request)
    {
        var result = await handler.LoginAsync(request);
        
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.Unauthorized();
    }
}

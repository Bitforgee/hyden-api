using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Requests.Auth;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Auth;

public class ResetPasswordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/reset-password", HandleAsync)
            .WithName("Auth: ResetPassword")
            .WithSummary("Redefine a senha de um usuário após a validação do código de verificação.")
            .WithDescription("Permite redefinir a senha informando email, código de verificação válido e a nova senha.")
            .WithOrder(3)
            .Produces<Response<string>>(StatusCodes.Status200OK)
            .Produces<Response<string>>(StatusCodes.Status400BadRequest)
            .Produces<Response<string>>(StatusCodes.Status500InternalServerError)
            .AllowAnonymous();


    private static async Task<IResult> HandleAsync(
        IAuthHandler handler,
        ResetPasswordRequest request)
    {
        var result = await handler.ResetPasswordAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

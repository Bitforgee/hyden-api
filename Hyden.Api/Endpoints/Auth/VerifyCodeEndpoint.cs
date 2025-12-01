using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Requests.Auth;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Auth;

public class VerifyCodeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/verify-code", HandleAsync)
            .WithName("Auth: VerifyCode")
            .WithSummary("Valida um código de verificação informado pelo usuário.")
            .WithDescription("Confere o código enviado por e-mail de acordo com o propósito (register, login, resetPassword, changeEmail).")
            .WithOrder(3)
            .Produces<Response<string>>()
            .AllowAnonymous();


    private static async Task<IResult> HandleAsync(
        IAuthHandler handler,
        VerifyCodeRequest request)
    {
        var result = await handler.VerifyCodeAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

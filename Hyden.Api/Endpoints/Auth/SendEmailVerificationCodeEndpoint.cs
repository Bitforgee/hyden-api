using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Requests.Auth;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Auth;

public class SendEmailVerificationCodeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/send-verification-code", HandleAsync)
            .WithName("Auth: SendVerificationCode")
            .WithSummary("Envia um código de verificação para o e-mail informado.")
            .WithDescription("Gera um código conforme o tipo (register, login, resetPassword, changeEmail) e envia por e-mail.")
            .WithOrder(1)
            .Produces<Response<string>>()
            .AllowAnonymous();


    private static async Task<IResult> HandleAsync(
        IAuthHandler handler,
        SendVerificationCodeRequest request)
    {
        var result = await handler.SendVerificationCodeAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

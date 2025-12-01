using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Notifications;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Notifications;

public class GetNotificationsUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapGet("/{userId:guid}", HandleAsync)
           .WithName("Notifications: Get by User")
           .WithSummary("Obtém notificações de um usuário")
           .WithDescription("Retorna todas as notificações vinculadas ao usuário especificado.")
           .WithOrder(1)
           .Produces<Response<List<UserNotification>>>(StatusCodes.Status200OK)
           .Produces<Response<List<UserNotification>>>(StatusCodes.Status401Unauthorized)
           .Produces<Response<List<UserNotification>>>(StatusCodes.Status404NotFound)
           .Produces<Response<List<UserNotification>>>(StatusCodes.Status500InternalServerError)
           .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        IUserNotificationHandler handler,
        Guid userId)
    {
        var request = new GetNotificationUserRequest { UserId = userId };
        var result = await handler.GetNotificationsByUser(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}

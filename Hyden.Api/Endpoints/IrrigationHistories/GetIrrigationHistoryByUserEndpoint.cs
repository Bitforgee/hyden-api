using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.IrrigationHistories;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.IrrigationHistories;

public class GetIrrigationHistoryByUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
      => app.MapGet("/user/{userId:guid}", HandleAsync)
          .WithName("Irrigation: Get by User")
          .WithSummary("Obtém histórico de irrigação de um usuário")
          .WithDescription("Retorna todo o histórico de irrigação de todos os SmartPots vinculados ao usuário.")
          .WithOrder(1)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status200OK)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status400BadRequest)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status404NotFound)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status500InternalServerError)
          .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        IIrrigationHistoryhandler handler,
        Guid userId)
    {
        var request = new GetIrrigationHistoryRequest { UserId = userId };
        var result = await handler.GetIrrigationHistoryByUser(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}

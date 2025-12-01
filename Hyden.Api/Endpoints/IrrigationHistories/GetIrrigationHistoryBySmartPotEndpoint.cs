using Hyden.Api.Common.Api;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.IrrigationHistories;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.IrrigationHistories;

public class GetIrrigationHistoryBySmartPotEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
      => app.MapGet("/smartpot/{userId:guid}/{smartPotId:guid}", HandleAsync)
          .WithName("Irrigation: Get by SmartPot")
          .WithSummary("Obtém histórico de irrigação de um SmartPot")
          .WithDescription("Retorna o histórico de irrigação de um SmartPot específico vinculado ao usuário.")
          .WithOrder(2)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status200OK)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status400BadRequest)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status403Forbidden)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status404NotFound)
          .Produces<Response<List<IrrigationHistory>>>(StatusCodes.Status500InternalServerError)
          .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        IIrrigationHistoryhandler handler,
        Guid userId,
        Guid smartPotId)
    {
        var request = new GetIrrigationHistoryBySmartPotRequest 
        { 
            UserId = userId,
            SmartPotId = smartPotId
        };
        var result = await handler.GetIrrigationHistoryBySmartPot(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(result);
    }
}
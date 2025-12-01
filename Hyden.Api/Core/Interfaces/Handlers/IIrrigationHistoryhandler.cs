using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.IrrigationHistories;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Core.Interfaces.Handlers
{
    public interface IIrrigationHistoryhandler
    {
        Task<Response<List<IrrigationHistory>>> GetIrrigationHistoryByUser(GetIrrigationHistoryRequest request);
        Task<Response<List<IrrigationHistory>>> GetIrrigationHistoryBySmartPot(GetIrrigationHistoryBySmartPotRequest request);
    }
}

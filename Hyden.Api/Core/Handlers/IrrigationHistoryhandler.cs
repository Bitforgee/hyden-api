using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.IrrigationHistories;
using Hyden.Api.Core.Responses;
using Hyden.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Core.Handlers
{
    public class IrrigationHistoryhandler(HydenDbContext context) : IIrrigationHistoryhandler
    {

        public async Task<Response<List<IrrigationHistory>>> GetIrrigationHistoryBySmartPot(GetIrrigationHistoryBySmartPotRequest request)
        {
            try
            {
                if (request.UserId == Guid.Empty)
                    return new Response<List<IrrigationHistory>>(null, 400, "Usuário inválido.");

                if (request.SmartPotId == Guid.Empty)
                    return new Response<List<IrrigationHistory>>(null, 400, "SmartPot inválido.");

                var userHasSmartPot = await context.UserSmartPots
                    .AnyAsync(usp => usp.UserId == request.UserId && usp.SmartPotId == request.SmartPotId);

                if (!userHasSmartPot)
                    return new Response<List<IrrigationHistory>>(null, 403, "Usuário não possui acesso a este SmartPot.");

                var histories = await context.IrrigationHistories
                    .Where(ih => ih.SmartPotId == request.SmartPotId)
                    .OrderByDescending(ih => ih.Timestamp)
                    .ToListAsync();

                if (histories.Count == 0)
                    return new Response<List<IrrigationHistory>>(null, 404, "Nenhum histórico de irrigação encontrado para este SmartPot.");

                return new Response<List<IrrigationHistory>>(histories, 200, "Histórico de irrigação recuperado com sucesso!");
            }
            catch
            {
                return new Response<List<IrrigationHistory>>(null, 500, "Erro ao buscar histórico de irrigação.");
            }
        }

        public async Task<Response<List<IrrigationHistory>>> GetIrrigationHistoryByUser(GetIrrigationHistoryRequest request)
        {
            try
            {
                if (request.UserId == Guid.Empty)
                    return new Response<List<IrrigationHistory>>(null, 400, "Usuário inválido.");

                var userSmartPotIds = await context.UserSmartPots
                    .Where(usp => usp.UserId == request.UserId)
                    .Select(usp => usp.SmartPotId)
                    .ToListAsync();

                if (userSmartPotIds.Count == 0)
                    return new Response<List<IrrigationHistory>>(null, 404, "Usuário não possui SmartPots vinculados.");

                var histories = await context.IrrigationHistories
                    .Include(ih => ih.SmartPot)
                    .Where(ih => userSmartPotIds.Contains(ih.SmartPotId))
                    .OrderByDescending(ih => ih.Timestamp)
                    .ToListAsync();

                if (histories.Count == 0)
                    return new Response<List<IrrigationHistory>>(null, 404, "Nenhum histórico de irrigação encontrado.");

                return new Response<List<IrrigationHistory>>(histories, 200, "Histórico de irrigação recuperado com sucesso!");
            }
            catch
            {
                return new Response<List<IrrigationHistory>>(null, 500, "Erro ao buscar histórico de irrigação.");
            }
        }
    }
}

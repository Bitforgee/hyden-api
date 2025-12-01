using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Notifications;
using Hyden.Api.Core.Responses;
using Hyden.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Core.Handlers;

public class UserNotificationHandler(HydenDbContext context) : IUserNotificationHandler
{
    public async Task<Response<List<UserNotification>>> GetNotificationsByPeriod(GetNotificationUserByPeriodRequest request)
    {
        try
        {
            if (request.UserId == Guid.Empty)
                return new Response<List<UserNotification>>(null, 400, "Usuário inválido.");

            if (request.StartDate == default || request.EndDate == default)
                return new Response<List<UserNotification>>(null, 400, "Período inválido.");

            if (request.StartDate > request.EndDate)
                return new Response<List<UserNotification>>(null, 400, "A data inicial não pode ser maior que a final.");

            var notifications = await context
                .UserNotifications
                .Where(n =>
                    n.UserId == request.UserId &&
                    n.CreatedAt >= request.StartDate &&
                    n.CreatedAt <= request.EndDate)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            if (notifications == null || notifications.Count == 0)
                return new Response<List<UserNotification>>(null, 404, "Nenhuma notificação encontrada no período especificado.");

            return new Response<List<UserNotification>>(notifications, 200, "Notificações filtradas com sucesso!");
        }
        catch
        {
            return new Response<List<UserNotification>>(null, 500, "Erro ao buscar notificações por período.");
        }
    }


    public async Task<Response<List<UserNotification>>> GetNotificationsByUser(GetNotificationUserRequest request)
    {
        try       
        {
            if (request.UserId == Guid.Empty)
                return new Response<List<UserNotification>>(null, 400, "Usuário inválido.");

            var notifications = await context
                .UserNotifications
                .Where(n => n.UserId == request.UserId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            if (notifications == null || notifications.Count == 0)
                return new Response<List<UserNotification>>(null, 404, "Nenhuma notificação encontrada.");

            return new Response<List<UserNotification>>(notifications, 200, "Notificações recuperadas com sucesso!");
        }
        catch
        {
            return new Response<List<UserNotification>>(null, 500, "Erro ao buscar notificações.");
        }
    }
}

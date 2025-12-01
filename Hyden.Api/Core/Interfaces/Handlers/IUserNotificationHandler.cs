using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Notifications;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Core.Interfaces.Handlers;

public interface IUserNotificationHandler
{
    Task<Response<List<UserNotification>>> GetNotificationsByUser(GetNotificationUserRequest request);
    Task<Response<List<UserNotification>>> GetNotificationsByPeriod(GetNotificationUserByPeriodRequest request);
}

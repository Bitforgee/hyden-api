using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Notifications;

public class GetNotificationUserRequest
{
    [Required(ErrorMessage = "O Id do usuário é obrigatório")]
    public Guid UserId { get; set; }
}

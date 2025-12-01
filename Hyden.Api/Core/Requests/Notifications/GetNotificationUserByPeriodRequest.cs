using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Notifications;

public class GetNotificationUserByPeriodRequest
{
    [Required(ErrorMessage = "O Id do usuário é obrigatório")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Data inicio é obrigatório")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Data fim é obrigatório")]
    public DateTime EndDate { get; set; }
}

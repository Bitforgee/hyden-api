using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.IrrigationHistories;

public class GetIrrigationHistoryRequest
{
    [Required(ErrorMessage = "O Id do usuário é obrigatório")]
    public Guid UserId { get; set; }
}

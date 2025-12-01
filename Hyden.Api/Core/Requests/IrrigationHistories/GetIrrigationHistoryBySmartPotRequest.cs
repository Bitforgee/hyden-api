using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.IrrigationHistories
{
    public class GetIrrigationHistoryBySmartPotRequest
    {
        [Required(ErrorMessage = "O Id do usuário é obrigatório")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O Id da plannta é obrigatório")]
        public Guid SmartPotId { get; set; }
    }
}

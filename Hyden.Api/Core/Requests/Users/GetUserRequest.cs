using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users;

public class GetUserRequest
{
    [Required(ErrorMessage = "O Id do usuário é obrigatório")]
    public Guid UserId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users;

public class UserExistsRequest
{
    [Required(ErrorMessage = "O email é obrigatório")]
    public string Email { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users;

public class LoginUserRequest
{
    [Required(ErrorMessage = "O email é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Password { get; set; } = string.Empty;
}

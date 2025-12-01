using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users;

public class CreateUserRequest
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Password { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; } = false;
    public string ProfilePictureUrl { get; set; } = string.Empty;
}

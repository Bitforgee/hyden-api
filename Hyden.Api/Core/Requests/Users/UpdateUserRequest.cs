using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users;

public class UpdateUserRequest
{
    [Required(ErrorMessage = "O id do usuário é obrigatório")]
    public Guid Id { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

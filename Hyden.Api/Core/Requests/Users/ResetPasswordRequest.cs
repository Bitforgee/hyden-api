using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Users
{
    public class ResetPasswordRequest
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatório")]
        public string NewPassword { get; set; } = string.Empty;
    }
}

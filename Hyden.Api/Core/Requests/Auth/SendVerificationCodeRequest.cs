using Hyden.Api.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Auth;

public class SendVerificationCodeRequest
{
    [Required(ErrorMessage = "O email é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Nome é obrigatório.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Propósito é obrigatório.")]
    public VerificationPurpose Purpose { get; set; } = VerificationPurpose.Register;
}

using Hyden.Api.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hyden.Api.Core.Requests.Auth;

public class VerifyCodeRequest
{
    [Required(ErrorMessage = "O email é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Propósito é obrigatório.")]
    public VerificationPurpose Purpose { get; set; } = VerificationPurpose.Register;

    [Required(ErrorMessage = "O código de verificação é obrigatório.")]
    public string Code { get; set; } = string.Empty;
}

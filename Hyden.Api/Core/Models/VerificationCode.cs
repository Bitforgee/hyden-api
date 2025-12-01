using Hyden.Api.Core.Enums;

namespace Hyden.Api.Core.Models;

public class VerificationCode
{
    public string Email { get; set; }
    public string Code { get; set; }
    public VerificationPurpose Purpose { get; set; }
    public DateTime ExpiresAt { get; set; }
}
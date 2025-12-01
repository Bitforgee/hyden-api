using Hyden.Api.Core.Dtos;

namespace Hyden.Api.Core.Interfaces.Services;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string toEmail, string toName, string subject, string htmlContent);
    Task<bool> SendVerificationCodeAsync(string toEmail, string toName, string verificationCode);
    Task<bool> SendResetPasswordCodeAsync(string toEmail, string toName, string verificationCode);
}

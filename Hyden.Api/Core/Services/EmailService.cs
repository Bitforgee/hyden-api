using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Interfaces.Services;
using Hyden.Api.Core.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Hyden.Api.Core.Services;

public class EmailService : IEmailService
{
    private readonly HttpClient _httpClient;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public EmailService(IOptions<MailerSendSettings> options)
    {
        var settings = options.Value;
        _fromEmail = settings.FromEmail;
        _fromName = settings.FromName;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.mailersend.com/v1/")
        };
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.ApiKey);
    }

    public async Task<bool> SendEmailAsync(string toEmail, string toName, string subject, string htmlContent)
    {
        try
        {
            var request = new MailerSendDto
            {
                From = new MailerSendEmailDto { Email = _fromEmail, Name = _fromName },
                To = [new MailerSendEmailDto { Email = toEmail, Name = toName }],
                Subject = subject,
                Html = htmlContent
            };

            var json = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("email", content);

            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SendVerificationCodeAsync(string toEmail, string toName, string verificationCode)
    {
        var year = DateTime.Now.Year;
        var htmlContent = $@"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Código de Verificação - Hyden</title>
</head>

<body style='margin:0; padding:0; background:#f3f6f4; font-family:-apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>

    <table role='presentation' width='100%' style='border-collapse:collapse; background:#f3f6f4;'>
        <tr>
            <td align='center' style='padding:40px 20px;'>

                <table role='presentation' width='100%' style='max-width:650px; border-collapse:collapse; background:#ffffff; border-radius:14px; box-shadow:0 4px 12px rgba(0,0,0,0.10);'>

                    <!-- HEADER -->
                    <tr>
                        <td style='padding:50px 20px; background:linear-gradient(135deg, #43a047 0%, #2e7d32 100%); border-radius:14px 14px 0 0; text-align:center;'>
                            <div style='font-size:52px; margin-bottom:10px;'>🌱</div>
                            <h1 style='margin:0; font-size:34px; color:#ffffff; font-weight:800; letter-spacing:1px;'>HYDEN</h1>
                            <p style='margin:10px 0 0; font-size:14px; color:#dcedc8; letter-spacing:1px;'>
                                Smart Plant Care System
                            </p>
                        </td>
                    </tr>

                    <!-- MAIN CONTENT -->
                    <tr>
                        <td style='padding:40px 35px;'>

                            <h2 style='margin:0 0 25px 0; font-size:26px; font-weight:700; color:#2e7d32; text-align:center;'>
                                Código de Verificação
                            </h2>

                            <p style='color:#444; font-size:16px; line-height:1.6; text-align:center; margin-bottom:30px;'>
                                Olá <strong>{toName}</strong>,<br>
                                Use o código abaixo para confirmar sua conta:
                            </p>

                            <!-- CÓDIGO -->
                            <table role='presentation' width='100%' style='margin:30px 0;'>
                                <tr>
                                    <td align='center'>
                                        <div style='padding:28px 40px; background:#e8f5e9; border:3px solid #43a047; border-radius:14px; display:inline-block;'>
                                            <div style='font-family:""Courier New"", monospace; font-size:40px; font-weight:bold; color:#2e7d32; letter-spacing:10px;'>
                                                {verificationCode}
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>


                            <p style='margin-top:25px; font-size:14px; color:#666; text-align:center; line-height:1.6;'>
                                Se você não solicitou este código, basta ignorar este email.
                            </p>
                        </td>
                    </tr>

                    <!-- FOOTER -->
                    <tr>
                        <td style='background:#f9f9f9; text-align:center; padding:30px; border-radius:0 0 14px 14px; border-top:1px solid #e0e0e0;'>

                            <p style='margin:0 0 5px; font-size:16px; color:#2e7d32; font-weight:bold;'>Hyden</p>
                            <p style='margin:0 0 12px; font-size:12px; color:#888;'>Smart Plant Care System</p>

                            <p style='margin:0; font-size:11px; color:#999;'>
                                &copy; {year} Hyden. Todos os direitos reservados.
                            </p>

                            <div style='margin-top:15px;'>
                                <span style='margin:0 8px; font-size:20px;'>🌿</span>
                                <span style='margin:0 8px; font-size:20px;'>💧</span>
                                <span style='margin:0 8px; font-size:20px;'>☀️</span>
                            </div>

                        </td>
                    </tr>

                </table>

                <!-- FOOTNOTE OUTSIDE -->
                <p style='margin-top:20px; max-width:650px; color:#999; font-size:11px; text-align:center; line-height:1.5;'>
                    Este é um email automático; por favor, não responda.<br>
                    Para suporte, entre em contato com nossa equipe.
                </p>

            </td>
        </tr>
    </table>

</body>
</html>";

        return await SendEmailAsync(toEmail, toName, "Código de Verificação - Hyden", htmlContent);
    }

    public async Task<bool> SendResetPasswordCodeAsync(string toEmail, string toName, string verificationCode)
    {
        var year = DateTime.Now.Year;
        var htmlContent = $@"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Redefinição de Senha - Hyden</title>
</head>

<body style='margin:0; padding:0; background:#f3f6f4; font-family:-apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>

    <table role='presentation' width='100%' style='border-collapse:collapse; background:#f3f6f4;'>
        <tr>
            <td align='center' style='padding:40px 20px;'>

                <table role='presentation' width='100%' style='max-width:650px; border-collapse:collapse; background:#ffffff; border-radius:14px; box-shadow:0 4px 12px rgba(0,0,0,0.10);'>

                    <!-- HEADER -->
                    <tr>
                        <td style='padding:50px 20px; background:linear-gradient(135deg, #43a047 0%, #2e7d32 100%); border-radius:14px 14px 0 0; text-align:center;'>
                            <div style='font-size:52px; margin-bottom:10px;'>🔐</div>
                            <h1 style='margin:0; font-size:34px; color:#ffffff; font-weight:800; letter-spacing:1px;'>Redefinir Senha</h1>
                            <p style='margin:10px 0 0; font-size:14px; color:#dcedc8; letter-spacing:1px;'>
                                Sistema de Segurança Hyden
                            </p>
                        </td>
                    </tr>

                    <!-- MAIN CONTENT -->
                    <tr>
                        <td style='padding:40px 35px;'>

                            <h2 style='margin:0 0 25px 0; font-size:26px; font-weight:700; color:#2e7d32; text-align:center;'>
                                Código de Redefinição
                            </h2>

                            <p style='color:#444; font-size:16px; line-height:1.6; text-align:center; margin-bottom:30px;'>
                                Olá <strong>{toName}</strong>,<br>
                                Use o código abaixo para redefinir sua senha:
                            </p>

                            <!-- CÓDIGO -->
                            <table role='presentation' width='100%' style='margin:30px 0;'>
                                <tr>
                                    <td align='center'>
                                        <div style='padding:28px 40px; background:#e8f5e9; border:3px solid #43a047; border-radius:14px; display:inline-block;'>
                                            <div style='font-family:""Courier New"", monospace; font-size:40px; font-weight:bold; color:#2e7d32; letter-spacing:10px;'>
                                                {verificationCode}
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                            <p style='margin-top:25px; font-size:14px; color:#666; text-align:center; line-height:1.6;'>
                                Se você não solicitou essa redefinição, por favor, ignore este e-mail.
                            </p>
                        </td>
                    </tr>

                    <!-- FOOTER -->
                    <tr>
                        <td style='background:#f9f9f9; text-align:center; padding:30px; border-radius:0 0 14px 14px; border-top:1px solid #e0e0e0;'>

                            <p style='margin:0 0 5px; font-size:16px; color:#2e7d32; font-weight:bold;'>Hyden</p>
                            <p style='margin:0 0 12px; font-size:12px; color:#888;'>Smart Plant Care System</p>

                            <p style='margin:0; font-size:11px; color:#999;'>
                                &copy; {year} Hyden. Todos os direitos reservados.
                            </p>

                            <div style='margin-top:15px;'>
                                <span style='margin:0 8px; font-size:20px;'>🌿</span>
                                <span style='margin:0 8px; font-size:20px;'>💧</span>
                                <span style='margin:0 8px; font-size:20px;'>☀️</span>
                            </div>

                        </td>
                    </tr>

                </table>

                <!-- FOOTNOTE OUTSIDE -->
                <p style='margin-top:20px; max-width:650px; color:#999; font-size:11px; text-align:center; line-height:1.5;'>
                    Este é um email automático; por favor, não responda.<br>
                    Para suporte, entre em contato com nossa equipe.
                </p>

            </td>
        </tr>
    </table>

</body>
</html>";

        return await SendEmailAsync(
            toEmail,
            toName,
            "Redefinição de Senha - Hyden",
            htmlContent
        );
    }

}

using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Enums;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Interfaces.Services;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Auth;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;
using Hyden.Api.Core.Services;
using Hyden.Api.Data;

namespace Hyden.Api.Core.Handlers;

public class AuthHandler(HydenDbContext context, ICryptoService cryptoService, ITokenService tokenService, IEmailService emailService) : IAuthHandler
{

    public async Task<Response<AuthResponseDto>> LoginAsync(LoginUserRequest request)
    {
        try
        {
            var user = context.Users.FirstOrDefault(u => u.Email.Equals(request.Email));

            if (user is null)
                return new Response<AuthResponseDto?>(null, 401, "Email ou senha inválidos");

            var passwordDecrypted = cryptoService.Decrypt(user.PasswordHash);

            if (!passwordDecrypted.Equals(request.Password))
                return new Response<AuthResponseDto?>(null, 401, "Email ou senha inválidos");

            var accessToken = tokenService.GenerateAccessToken(user);

            var token = new AuthResponseDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                profilePictureUrl = user.ProfilePictureUrl,
                AccessToken = accessToken,
                TokenType = "Bearer",
                ExpiresIn = 3600
            };

            return new Response<AuthResponseDto>(token, 200, "Login realizado com sucesso!");
        }
        catch
        {
            return new Response<AuthResponseDto?>(null, 500, "Erro ao realizar login");
        }
    }

    public async Task<Response<VerificationCode>> SendVerificationCodeAsync(SendVerificationCodeRequest request)
    {
        try
        {

            if (request.Purpose is VerificationPurpose.ResetPassword)
            {
                var user = context.Users.FirstOrDefault(u => u.Email == request.Email);

                if (user is null)
                    return new Response<VerificationCode>(null, 404, "Usuário não encontrado.");

                request.Name = user.Name;
            }

            var code = new Random().Next(100000, 999999).ToString();

            var existing = context.VerificationCodes
                .Where(v => v.Email == request.Email && v.Purpose == request.Purpose);

            context.VerificationCodes.RemoveRange(existing);

            var verification = new VerificationCode
            {
                Email = request.Email,
                Code = code,
                Purpose = request.Purpose,
                ExpiresAt = DateTime.UtcNow.AddMinutes(10)
            };

            context.VerificationCodes.Add(verification);
            await context.SaveChangesAsync();

            switch (request.Purpose)
            {
                case VerificationPurpose.Register:
                    await emailService.SendVerificationCodeAsync(request.Email, request.Name, code);
                break;
                case VerificationPurpose.ResetPassword:
                    await emailService.SendResetPasswordCodeAsync(request.Email, request.Name, code);
                    break;

                default:
                    return new Response<VerificationCode>(null, 400, "Tipo de verificação inválido.");
            }

            return new Response<VerificationCode>(null, 200, "Código enviado com sucesso.");
        }
        catch (Exception)
        {
            return new Response<VerificationCode>(null, 500, "Erro ao enviar o código.");
        }
    }

    public async Task<Response<VerificationCode>> VerifyCodeAsync(VerifyCodeRequest request)
    {
        try
        {
            var code = context.VerificationCodes.FirstOrDefault(x => x.Email == request.Email &&
                                                                x.Purpose == request.Purpose &&
                                                                x.Code == request.Code &&
                                                                x.ExpiresAt > DateTime.UtcNow);

            if (code == null)
                return new Response<VerificationCode>(null, 400, "Código inválido.");

            context.VerificationCodes.Remove(code);
            await context.SaveChangesAsync();

            return new Response<VerificationCode>(code, 200, "Código válido.");
        }
        catch (Exception)
        {

            return new Response<VerificationCode>(null, 500, "Erro ao verificar o código.");
        }
    }

    public async Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request)
    {
        try
        {
            var user = context.Users.FirstOrDefault(u => u.Email.Equals(request.Email));

            if (user is null)
                return new Response<bool>(false, 404, "Usuário não encontrado");

            var passwordEncrypted = cryptoService.Encrypt(request.NewPassword);

            user.ResetPassword(passwordEncrypted);

            await context.SaveChangesAsync();

            return new Response<bool>(true, 200, "Dados alterados com sucesso!");
        }
        catch
        {
            return new Response<bool>(false, 500, "Não foi possível alterar os dados do usuário");
        }
    }
}

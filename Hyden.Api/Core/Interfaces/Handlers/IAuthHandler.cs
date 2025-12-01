using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Auth;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Core.Interfaces.Handlers;

public interface IAuthHandler
{
    Task<Response<AuthResponseDto>> LoginAsync(LoginUserRequest request);
    Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request);
    Task<Response<VerificationCode>> SendVerificationCodeAsync(SendVerificationCodeRequest request);
    Task<Response<VerificationCode>> VerifyCodeAsync(VerifyCodeRequest request);
}

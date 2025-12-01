using System.Security.Claims;
using Hyden.Api.Core.Models;

namespace Hyden.Api.Core.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

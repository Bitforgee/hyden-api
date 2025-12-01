using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Core.Interfaces.Handlers;

public interface IUserHandler
{
    Task<Response<User>> CreateAsync(CreateUserRequest request);
    Task<Response<User>> UpdateAsync(UpdateUserRequest request);
    Task<Response<User>> GetUser(GetUserRequest request);
    Task<Response<User>> UserExistsAsync(UserExistsRequest request);
    Task<Response<UploadDto>> UploadProfilePictureAsync(UploadProfilePictureRequest request);
}

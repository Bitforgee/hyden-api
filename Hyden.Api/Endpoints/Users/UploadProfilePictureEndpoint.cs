using Hyden.Api.Common.Api;
using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;

namespace Hyden.Api.Endpoints.Users;

public class UploadProfilePictureEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/upload-profile-picture", HandleAsync)
            .WithName("Users: Upload Profile Picture")
            .WithSummary("Faz upload da foto de perfil do usuário")
            .WithDescription("Upload de imagem para perfil do usuário no Cloudinary")
            .WithOrder(3)
            .Produces<Response<UploadDto>>(StatusCodes.Status200OK)
            .Produces<Response<UploadDto>>(StatusCodes.Status400BadRequest)
            .Produces<Response<UploadDto>>(StatusCodes.Status401Unauthorized)
            .Produces<Response<UploadDto>>(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        IUserHandler handler,
        UploadProfilePictureRequest request)
    {
        var result = await handler.UploadProfilePictureAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Message);
    }
}
using Hyden.Api.Common.Api;
using Hyden.Api.Endpoints.Auth;
using Hyden.Api.Endpoints.IrrigationHistories;
using Hyden.Api.Endpoints.Notifications;
using Hyden.Api.Endpoints.Users;

namespace Hyden.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("v1/users")
            .WithTags("Users")
            .MapEndpoint<CreateUserEndpoint>()
            .MapEndpoint<UpdateUserEndpoint>()
            .MapEndpoint<UploadProfilePictureEndpoint>()
            .MapEndpoint<GetUserEndpoint>()
            .MapEndpoint<UserExistsEndpoint>();


        endpoints.MapGroup("v1/auth")
            .WithTags("Auth")
            .MapEndpoint<LoginUserEndpoint>()
            .MapEndpoint<SendEmailVerificationCodeEndpoint>()
            .MapEndpoint<VerifyCodeEndpoint>()
            .MapEndpoint<ResetPasswordEndpoint>();

        endpoints.MapGroup("v1/notifications")
           .WithTags("Notifications")
           .MapEndpoint<GetNotificationsUserEndpoint>();

        endpoints.MapGroup("v1/irrigation-histories")
           .WithTags("Irrigation Histories")
           .MapEndpoint<GetIrrigationHistoryByUserEndpoint>()
           .MapEndpoint<GetIrrigationHistoryBySmartPotEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
       where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}

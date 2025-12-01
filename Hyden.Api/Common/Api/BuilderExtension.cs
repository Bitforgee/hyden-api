using Hyden.Api.Core;
using Hyden.Api.Core.Handlers;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Interfaces.Services;
using Hyden.Api.Core.Services;
using Hyden.Api.Core.Settings;
using Hyden.Api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

namespace Hyden.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(
        this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString =
            builder
                .Configuration
                .GetConnectionString("DefaultConnection")
            ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);

            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Hyden API",
                Version = "v1"
            });
            
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            
            x.AddSecurityRequirement(doc => 
            {
                var scheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                };
                
                var requirement = new OpenApiSecurityRequirement();
                requirement.Add(new OpenApiSecuritySchemeReference("Bearer"), new List<string>());
                return requirement;
            });
        });
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>() 
            ?? new JwtSettings { SecretKey = "YourVerySecureSecretKeyForJWTTokenGenerationMinimum32CharactersLong!" };
        
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey.Length >= 32 
            ? jwtSettings.SecretKey 
            : jwtSettings.SecretKey.PadRight(32, '0'));

        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = "HydenApi",
                    ValidateAudience = true,
                    ValidAudience = "HydenApp",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        builder.Services.AddAuthorization();
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<HydenDbContext>(
                x => { x.UseNpgsql(Configuration.ConnectionString); });
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        // Configurar Options Pattern
        builder.Services.Configure<CryptoSettings>(builder.Configuration.GetSection("Crypto"));
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
        builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
        builder.Services.Configure<MailerSendSettings>(builder.Configuration.GetSection("MailerSend"));

        // Registrar serviços
        builder.Services.AddScoped<ICryptoService, CryptoService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddTransient<IUserHandler, UserHandler>();
        builder.Services.AddTransient<IAuthHandler, AuthHandler>();
    }
}

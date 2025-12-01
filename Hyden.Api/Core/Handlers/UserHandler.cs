using Hyden.Api.Core.Dtos;
using Hyden.Api.Core.Interfaces.Handlers;
using Hyden.Api.Core.Interfaces.Services;
using Hyden.Api.Core.Models;
using Hyden.Api.Core.Requests.Users;
using Hyden.Api.Core.Responses;
using Hyden.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Core.Handlers;

public class UserHandler(HydenDbContext context, ICryptoService cryptoService, ICloudinaryService cloudinaryService) : IUserHandler
{
    public async Task<Response<User>> CreateAsync(CreateUserRequest request)
    {
        try
        {
            var userExist = context.Users.Any(u => u.Email.Equals(request.Email));

            if (userExist)
                return new Response<User?>(null, 409, "Usuário com este email já existe");

            var passwordEncrypted = cryptoService.Encrypt(request.Password);

            var user = new User(request.Username, request.Email, passwordEncrypted, request.ProfilePictureUrl, request.EmailConfirmed);

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new Response<User?>(user, 201, "Categoria criada com sucesso!");
        }
        catch
        {
            return new Response<User?>(null, 500, "Não foi possível criar a categoria");
        }
    }

    public async Task<Response<User>> GetUser(GetUserRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserId.ToString()))
                return new Response<User?>(null, 500, "Não foi possível");

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.UserId));

            if (user is null)
                return new Response<User?>(null, 404, "Usuário não encontrado");

            return new Response<User?>(user, 200, "Usuário recuperado com sucesso!");
        }
        catch
        {
            return new Response<User?>(null, 500, "Não foi possível buscar pelo usuário especificado");
        }
    }

    public async Task<Response<User>> UserExistsAsync(UserExistsRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Email.ToString()))
                return new Response<User?>(null, 500, $"Não foi possível encontrar o usuário pelo email {request.Email}");

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email.Equals(request.Email));

            if (user is null)
                return new Response<User?>(null, 404, "Usuário não encontrado");

            return new Response<User?>(user, 200, "Usuário recuperado com sucesso!");
        }
        catch
        {
            return new Response<User?>(null, 500, "Não foi possível buscar pelo usuário especificado");
        }
    }

    public async Task<Response<User>> UpdateAsync(UpdateUserRequest request)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(request.Id));

            if (user is null)
                return new Response<User?>(null, 404, "Usuário não encontrado");

            var name = $"{request.Name} {request.Surname}";
            user.Update(name, request.Email, request.ProfilePictureUrl);

            await context.SaveChangesAsync();

            return new Response<User?>(user, 200, "Dados alterados com sucesso!");
        }
        catch
        {
            return new Response<User?>(null, 500, "Não foi possível alterar os dados do usuário");
        }
    }

    public async Task<Response<UploadDto>> UploadProfilePictureAsync(UploadProfilePictureRequest request)
    {
        try
        {
            var allowedMimeTypes = new[]
            {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/webp"
        };

            if (!allowedMimeTypes.Contains(request.Mime.ToLower()))
                return new Response<UploadDto?>(null, 400, "Formato inválido. Use: jpg, jpeg, png, gif, webp");

            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(request.Base64);
            }
            catch
            {
                return new Response<UploadDto?>(null, 400, "Base64 inválido.");
            }

            if (imageBytes.Length > 5_242_880)
                return new Response<UploadDto?>(null, 400, "A imagem não pode exceder 5MB.");

            using var ms = new MemoryStream(imageBytes);

            var imageUrl = await cloudinaryService.UploadUserProfilePictureAsync(
                ms,
                request.PictureName,
                request.UserId);

            var response = new UploadDto
            {
                ImageUrl = imageUrl,
                PublicId = $"hyden/users/{request.UserId}/profile"
            };

            return new Response<UploadDto?>(response, 200, "Foto de perfil enviada com sucesso!");
        }
        catch (Exception)
        {
            return new Response<UploadDto?>(null, 500, "Erro ao enviar a foto do usuário.");
        }
    }

}

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Hyden.Api.Core.Interfaces.Services;
using Hyden.Api.Core.Settings;
using Microsoft.Extensions.Options;

namespace Hyden.Api.Core.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> options)
    {
        var settings = options.Value;
        var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadUserProfilePictureAsync(Stream imageStream, string fileName, string userId)
    {
        try
        {
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(fileName, imageStream),
                PublicId = $"hyden/users/{userId}/profile",
                Folder = "hyden/users",
                Overwrite = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                throw new InvalidOperationException($"Cloudinary upload error: {uploadResult.Error.Message}");

            return uploadResult.SecureUrl?.ToString() ?? string.Empty;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to upload user profile picture: {ex.Message}", ex);
        }
    }

    public async Task<string> UploadPlantPictureAsync(Stream imageStream, string fileName, string plantId)
    {
        try
        {
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(fileName, imageStream),
                PublicId = $"hyden/plants/{plantId}/photo",
                Folder = "hyden/plants",
                Overwrite = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                throw new InvalidOperationException($"Cloudinary upload error: {uploadResult.Error.Message}");

            return uploadResult.SecureUrl?.ToString() ?? string.Empty;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to upload plant picture: {ex.Message}", ex);
        }
    }

    public async Task<string> UploadSmartPotPictureAsync(Stream imageStream, string fileName, string smartPotId)
    {
        try
        {
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(fileName, imageStream),
                PublicId = $"hyden/smartpots/{smartPotId}/photo",
                Folder = "hyden/smartpots",
                Overwrite = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                throw new InvalidOperationException($"Cloudinary upload error: {uploadResult.Error.Message}");

            return uploadResult.SecureUrl?.ToString() ?? string.Empty;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to upload smart pot picture: {ex.Message}", ex);
        }
    }

    public async Task<bool> DeleteImageAsync(string publicId)
    {
        try
        {
            var deleteParams = new DeletionParams(publicId);
            var deleteResult = await _cloudinary.DestroyAsync(deleteParams);

            return deleteResult.Result == "ok";
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to delete image: {ex.Message}", ex);
        }
    }
}

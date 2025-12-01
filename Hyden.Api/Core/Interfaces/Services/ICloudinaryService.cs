namespace Hyden.Api.Core.Interfaces.Services;

public interface ICloudinaryService
{
    Task<string> UploadUserProfilePictureAsync(Stream imageStream, string fileName, string userId);
    Task<string> UploadPlantPictureAsync(Stream imageStream, string fileName, string plantId);
    Task<string> UploadSmartPotPictureAsync(Stream imageStream, string fileName, string smartPotId);
    Task<bool> DeleteImageAsync(string publicId);
}

using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string? ProfilePictureUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private User() { }

    public User(string name, string email, string passwordHash, string pictureUrl , bool emailConfirmed)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        EmailConfirmed = emailConfirmed;
        ProfilePictureUrl = pictureUrl;
        CreatedAt = DateTimeHelper.UtcNowCuiaba;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
    public void Update(string name, string email, string pictureUrl)
    {
        Name = name;
        Email = email;
        ProfilePictureUrl = pictureUrl;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }

    public void ResetPassword(string newPasswordHash) => PasswordHash = newPasswordHash;

    public void UpdateProfilePicture(string pictureUrl)
    {
        ProfilePictureUrl = pictureUrl;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

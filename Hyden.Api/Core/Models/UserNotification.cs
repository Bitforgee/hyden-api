using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class UserNotification
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public User? UserNotified { get; private set; }
    public bool IsRead { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }
    public int Type { get; private set; }
    public DateTime SentAt { get; private set; }
    public int Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private UserNotification() { }

    public UserNotification(Guid userId, string title, string message, int type, int status = 0)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        IsRead = false;
        Title = title;
        Message = message;
        Type = type;
        SentAt = DateTimeHelper.UtcNowCuiaba;
        Status = status;
        CreatedAt = DateTimeHelper.UtcNowCuiaba;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

using Flunt.Notifications;

namespace Hyden.Api.Domain.Entities;

public sealed class UserNotification : Notifiable<Notification>
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
}

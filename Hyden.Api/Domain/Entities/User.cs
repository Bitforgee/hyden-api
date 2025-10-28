using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;

namespace Hyden.Api.Domain.Entities;

public sealed class User : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public bool? EmailConfirmed { get; private set; }
    private User() { }
}

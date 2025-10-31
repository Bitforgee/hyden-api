using Flunt.Notifications;

namespace Hyden.Api.Domain.Entities;

public sealed class SmartPot : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public string QrCode { get; private set; }
    public string Location { get; private set; }
    public bool ConnectionStatus { get; private set; }
    public double ReservoirLevel { get; private set; }
    public double LastSoilMoisture { get; private set; }
    public DateTime LastIrrigation { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private SmartPot() { }
}

using Flunt.Notifications;

namespace Hyden.Api.Domain.Entities;

public sealed class IrrigationHistory : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public Guid SmartPotId { get; private set; }
    public SmartPot? SmartPot { get; private set; }
    public DateTime Timestamp { get; private set; }
    public double WaterAmount { get; private set; }
    public double MoistureBefore { get; private set; }
    public double MoistureAfter { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private IrrigationHistory() { }
}

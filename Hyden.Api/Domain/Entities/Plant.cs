using Flunt.Notifications;

namespace Hyden.Api.Domain.Entities;

public sealed class Plant : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public Guid SmartPotId { get; private set; }
    public SmartPot? SmartPot { get; private set; }
    public Guid PlantSpecificationId { get; private set; }
    public PlantSpecification? PlantSpecification { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private Plant() { }
}

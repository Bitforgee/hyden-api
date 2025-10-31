using Flunt.Notifications;

namespace Hyden.Api.Domain.Entities;

public sealed class PlantSpecification : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public string CommonName { get; private set; }
    public string ScientificName { get; private set; }
    public int Type { get; private set; }
    public double IdealTempMin { get; private set; }
    public double IdealTempMax { get; private set; }
    public string Light { get; private set; }
    public string WateringFrequency { get; private set; }
    public string Notes { get; private set; }
    public double IdealMoistureMin { get; private set; }
    public double IdealMoistureMax { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private PlantSpecification() { }
}

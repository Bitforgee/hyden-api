using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class Plant
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

    public Plant(string name, Guid smartPotId, Guid plantSpecificationId)
    {
        Id = Guid.NewGuid();
        Name = name;
        RegistrationDate = DateTimeHelper.UtcNowCuiaba;
        SmartPotId = smartPotId;
        PlantSpecificationId = plantSpecificationId;
        CreatedAt = DateTimeHelper.UtcNowCuiaba;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

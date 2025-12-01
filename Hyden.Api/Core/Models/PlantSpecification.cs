using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class PlantSpecification
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

    public PlantSpecification(string commonName, string scientificName, int type, double idealTempMin, 
        double idealTempMax, string light, string wateringFrequency, string notes, 
        double idealMoistureMin, double idealMoistureMax)
    {
        Id = Guid.NewGuid();
        CommonName = commonName;
        ScientificName = scientificName;
        Type = type;
        IdealTempMin = idealTempMin;
        IdealTempMax = idealTempMax;
        Light = light;
        WateringFrequency = wateringFrequency;
        Notes = notes;
        IdealMoistureMin = idealMoistureMin;
        IdealMoistureMax = idealMoistureMax;
        CreatedAt = DateTimeHelper.UtcNowCuiaba;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

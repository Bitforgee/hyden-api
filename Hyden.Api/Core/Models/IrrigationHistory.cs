using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class IrrigationHistory
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

    public IrrigationHistory(Guid smartPotId, double waterAmount, double moistureBefore, double moistureAfter)
    {
        Id = Guid.NewGuid();
        SmartPotId = smartPotId;
        Timestamp = DateTimeHelper.UtcNowCuiaba;
        WaterAmount = waterAmount;
        MoistureBefore = moistureBefore;
        MoistureAfter = moistureAfter;
        CreatedAt = DateTimeHelper.UtcNowCuiaba;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

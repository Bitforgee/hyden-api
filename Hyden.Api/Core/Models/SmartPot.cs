using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class SmartPot
{
    public Guid Id { get; private set; }
    public string QrCode { get; private set; }
    public string Location { get; private set; }
    public string SerialNumber { get; private set; }
    public bool ConnectionStatus { get; private set; }
    public double ReservoirLevel { get; private set; }
    public double LastSoilMoisture { get; private set; }
    public DateTime LastIrrigation { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    private SmartPot() { }

    public SmartPot(string qrCode, string location, string serialNumber)
    {
        Id = Guid.NewGuid();
        QrCode = qrCode;
        Location = location;
        SerialNumber = serialNumber;
        ConnectionStatus = false;
        ReservoirLevel = 0;
        LastSoilMoisture = 0;
        LastIrrigation = DateTimeHelper.UtcNowCuiaba;
        CreatedAt = DateTimeHelper.UtcNowCuiaba;
        UpdatedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

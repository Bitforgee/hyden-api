using Hyden.Api.Core.Utils;

namespace Hyden.Api.Core.Models;

public sealed class UserSmartPot
{
    public Guid UserId { get; private set; }
    public Guid SmartPotId { get; private set; }
    public DateTime AssignedAt { get; private set; }

    public User User { get; private set; } = null!;
    public SmartPot SmartPot { get; private set; } = null!;

    private UserSmartPot() { }

    public UserSmartPot(Guid userId, Guid smartPotId)
    {
        UserId = userId;
        SmartPotId = smartPotId;
        AssignedAt = DateTimeHelper.UtcNowCuiaba;
    }
}

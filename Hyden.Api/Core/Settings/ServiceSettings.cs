namespace Hyden.Api.Core.Settings;

public class CryptoSettings
{
    public string Key { get; set; } = string.Empty;
    public string IV { get; set; } = string.Empty;
}

public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpirationMinutes { get; set; } = 60;
}

public class CloudinarySettings
{
    public string CloudName { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string ApiSecret { get; set; } = string.Empty;
}

public class MailjetSettings
{
    public string ApiKey { get; set; } = string.Empty;
    public string ApiSecret { get; set; } = string.Empty;
    public string FromEmail { get; set; } = "noreply@hyden.com";
    public string FromName { get; set; } = "Hyden";
}

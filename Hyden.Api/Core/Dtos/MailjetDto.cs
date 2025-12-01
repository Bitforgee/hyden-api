using System.Text.Json.Serialization;

namespace Hyden.Api.Core.Dtos;

public class MailjetRequestDto
{
    [JsonPropertyName("Messages")]
    public required List<MailjetMessageDto> Messages { get; set; }
}

public class MailjetMessageDto
{
    [JsonPropertyName("From")]
    public required MailjetEmailDto From { get; set; }
    
    [JsonPropertyName("To")]
    public required List<MailjetEmailDto> To { get; set; }
    
    [JsonPropertyName("Subject")]
    public required string Subject { get; set; }
    
    [JsonPropertyName("TextPart")]
    public string? TextPart { get; set; }
    
    [JsonPropertyName("HTMLPart")]
    public string? HTMLPart { get; set; }
}

public class MailjetEmailDto
{
    [JsonPropertyName("Email")]
    public required string Email { get; set; }
    
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}

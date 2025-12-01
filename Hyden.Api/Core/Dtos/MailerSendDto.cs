namespace Hyden.Api.Core.Dtos;

public class MailerSendDto
{
    public required MailerSendEmailDto From { get; set; }
    public required List<MailerSendEmailDto> To { get; set; }
    public required string Subject { get; set; }
    public string? Text { get; set; }
    public string? Html { get; set; }
}

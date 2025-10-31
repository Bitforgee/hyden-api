using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Infrastructure.Configurations;

public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.ToTable("USER_NOTIFICATIONS");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("USER_NOTIFICATION_ID");

        builder.Property(u => u.UserId)
            .HasColumnName("USER_ID")
            .IsRequired();

        builder.Property(u => u.IsRead)
            .HasColumnName("IS_READ");

        builder.Property(u => u.Title)
            .HasColumnName("TITLE")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Message)
            .HasColumnName("MESSAGE")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(u => u.Type)
            .HasColumnName("TYPE");

        builder.Property(u => u.SentAt)
            .HasColumnName("SENT_AT")
            .IsRequired();

        builder.Property(u => u.Status)
            .HasColumnName("STATUS");

        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .IsRequired();

        builder.HasOne(n => n.UserNotified)
            .WithMany()
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

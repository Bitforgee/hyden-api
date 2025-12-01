using System;
using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class UserNotificationMapping : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.ToTable("USER_NOTIFICATIONS");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("USER_NOTIFICATION_ID")
            .HasColumnType("uuid");

        builder.Property(u => u.UserId)
            .HasColumnName("USER_ID")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(u => u.IsRead)
            .HasColumnName("IS_READ")
            .HasColumnType("boolean");

        builder.Property(u => u.Title)
            .HasColumnName("TITLE")
            .HasColumnType("character varying(150)")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Message)
            .HasColumnName("MESSAGE")
            .HasColumnType("character varying(500)")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(u => u.Type)
            .HasColumnName("TYPE")
            .HasColumnType("integer");

        builder.Property(u => u.SentAt)
            .HasColumnName("SENT_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(u => u.Status)
            .HasColumnName("STATUS")
            .HasColumnType("integer");

        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasOne(n => n.UserNotified)
            .WithMany()
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

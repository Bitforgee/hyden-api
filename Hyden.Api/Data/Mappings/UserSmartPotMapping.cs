using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class UserSmartPotMapping : IEntityTypeConfiguration<UserSmartPot>
{
    public void Configure(EntityTypeBuilder<UserSmartPot> builder)
    {
        builder.ToTable("USER_SMART_POTS");

        builder.HasKey(us => new { us.UserId, us.SmartPotId });

        builder.Property(us => us.UserId)
            .HasColumnName("USER_ID")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(us => us.SmartPotId)
            .HasColumnName("SMART_POT_ID")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(us => us.AssignedAt)
            .HasColumnName("ASSIGNED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasOne(us => us.User)
            .WithMany()
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(us => us.SmartPot)
            .WithMany()
            .HasForeignKey(us => us.SmartPotId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(us => us.UserId);
        builder.HasIndex(us => us.SmartPotId);
    }
}

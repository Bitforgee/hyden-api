using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Infrastructure.Configurations;

public class IrrigationHistoryConfiguration : IEntityTypeConfiguration<IrrigationHistory>
{
    public void Configure(EntityTypeBuilder<IrrigationHistory> builder)
    {
        builder.ToTable("IRRIGATION_HISTORIES");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("IRRIGATION_HISTORY_ID");

        builder.Property(i => i.SmartPotId)
            .HasColumnName("SMART_POT_ID")
            .IsRequired();

        builder.Property(i => i.Timestamp)
            .HasColumnName("TIMESTAMP")
            .IsRequired();

        builder.Property(i => i.WaterAmount)
            .HasColumnName("WATER_AMOUNT");

        builder.Property(i => i.MoistureBefore)
            .HasColumnName("MOISTURE_BEFORE");

        builder.Property(i => i.MoistureAfter)
            .HasColumnName("MOISTURE_AFTER");

        builder.Property(i => i.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();

        builder.Property(i => i.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .IsRequired();

        builder.HasOne(i => i.SmartPot)
            .WithMany()
            .HasForeignKey(i => i.SmartPotId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

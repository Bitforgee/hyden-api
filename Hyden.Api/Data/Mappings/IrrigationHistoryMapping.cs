using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class IrrigationHistoryMapping : IEntityTypeConfiguration<IrrigationHistory>
{
    public void Configure(EntityTypeBuilder<IrrigationHistory> builder)
    {
        builder.ToTable("IRRIGATION_HISTORIES");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("IRRIGATION_HISTORY_ID")
            .HasColumnType("uuid");

        builder.Property(i => i.SmartPotId)
            .HasColumnName("SMART_POT_ID")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(i => i.Timestamp)
            .HasColumnName("TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(i => i.WaterAmount)
            .HasColumnName("WATER_AMOUNT")
            .HasColumnType("double precision");

        builder.Property(i => i.MoistureBefore)
            .HasColumnName("MOISTURE_BEFORE")
            .HasColumnType("double precision");

        builder.Property(i => i.MoistureAfter)
            .HasColumnName("MOISTURE_AFTER")
            .HasColumnType("double precision");

        builder.Property(i => i.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(i => i.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasOne(i => i.SmartPot)
            .WithMany()
            .HasForeignKey(i => i.SmartPotId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

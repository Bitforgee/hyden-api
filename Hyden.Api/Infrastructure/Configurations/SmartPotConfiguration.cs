using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Infrastructure.Configurations;

public class SmartPotConfiguration : IEntityTypeConfiguration<SmartPot>
{
    public void Configure(EntityTypeBuilder<SmartPot> builder)
    {
        builder.ToTable("SMART_POTS");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("SMART_POT_ID");

        builder.Property(s => s.QrCode)
            .HasColumnName("QR_CODE")
            .IsRequired();

        builder.Property(s => s.Location)
            .HasColumnName("LOCATION")
            .HasMaxLength(120);

        builder.Property(s => s.ConnectionStatus)
            .HasColumnName("CONNECTION_STATUS")
            .IsRequired();

        builder.Property(s => s.ReservoirLevel)
            .HasColumnName("RESERVOIR_LEVEL");

        builder.Property(s => s.LastSoilMoisture)
            .HasColumnName("LAST_SOIL_MOISTURE");

        builder.Property(s => s.LastIrrigation)
            .HasColumnName("LAST_IRRIGATION");

        builder.Property(s => s.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();

        builder.Property(s => s.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .IsRequired();

        builder.HasIndex(s => s.QrCode)
            .IsUnique();
    }
}

using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class SmartPotMapping : IEntityTypeConfiguration<SmartPot>
{
    public void Configure(EntityTypeBuilder<SmartPot> builder)
    {
        builder.ToTable("SMART_POTS");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("SMART_POT_ID")
            .HasColumnType("uuid");

        builder.Property(s => s.QrCode)
            .HasColumnName("QR_CODE")
            .HasColumnType("character varying(255)")
            .IsRequired();

        builder.Property(s => s.Location)
            .HasColumnName("LOCATION")
            .HasColumnType("character varying(120)")
            .HasMaxLength(120);

        builder.Property(s => s.SerialNumber)
            .HasColumnName("SERIAL_NUMBER")
            .HasColumnType("character varying(100)")
            .IsRequired();

        builder.Property(s => s.ConnectionStatus)
            .HasColumnName("CONNECTION_STATUS")
            .HasColumnType("boolean")
            .IsRequired();

        builder.Property(s => s.ReservoirLevel)
            .HasColumnName("RESERVOIR_LEVEL")
            .HasColumnType("double precision");

        builder.Property(s => s.LastSoilMoisture)
            .HasColumnName("LAST_SOIL_MOISTURE")
            .HasColumnType("double precision");

        builder.Property(s => s.LastIrrigation)
            .HasColumnName("LAST_IRRIGATION")
            .HasColumnType("timestamp with time zone");

        builder.Property(s => s.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(s => s.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasIndex(s => s.QrCode)
            .IsUnique();
    }
}

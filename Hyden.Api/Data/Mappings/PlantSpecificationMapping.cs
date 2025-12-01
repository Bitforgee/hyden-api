using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class PlantSpecificationMapping : IEntityTypeConfiguration<PlantSpecification>
{
    public void Configure(EntityTypeBuilder<PlantSpecification> builder)
    {
        builder.ToTable("PLANT_SPECS");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("PLANT_SPECIFICATION_ID")
            .HasColumnType("uuid");

        builder.Property(p => p.CommonName)
            .HasColumnName("COMMON_NAME")
            .HasColumnType("character varying(100)")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.ScientificName)
            .HasColumnName("SCIENTIFIC_NAME")
            .HasColumnType("character varying(100)")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Type)
            .HasColumnName("TYPE")
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(p => p.IdealTempMin)
            .HasColumnName("IDEAL_TEMP_MIN")
            .HasColumnType("double precision");

        builder.Property(p => p.IdealTempMax)
            .HasColumnName("IDEAL_TEMP_MAX")
            .HasColumnType("double precision");

        builder.Property(p => p.Light)
            .HasColumnName("LIGHT")
            .HasColumnType("character varying(100)")
            .HasMaxLength(100);

        builder.Property(p => p.WateringFrequency)
            .HasColumnName("WATERING_FREQUENCY")
            .HasColumnType("character varying(100)");

        builder.Property(p => p.IdealMoistureMin)
            .HasColumnName("IDEAL_MOISTURE_MIN")
            .HasColumnType("double precision");

        builder.Property(p => p.IdealMoistureMax)
            .HasColumnName("IDEAL_MOISTURE_MAX")
            .HasColumnType("double precision");

        builder.Property(p => p.Notes)
            .HasColumnName("NOTES")
            .HasColumnType("character varying(500)")
            .HasMaxLength(500);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}

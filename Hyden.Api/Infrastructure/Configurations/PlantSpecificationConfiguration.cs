using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Infrastructure.Configurations;

public class PlantSpecificationConfiguration : IEntityTypeConfiguration<PlantSpecification>
{
    public void Configure(EntityTypeBuilder<PlantSpecification> builder)
    {
        builder.ToTable("PLANT_SPECS");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("PLANT_SPECIFICATION_ID");

        builder.Property(p => p.CommonName)
            .HasColumnName("COMMON_NAME")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.ScientificName)
            .HasColumnName("SCIENTIFIC_NAME")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Type)
            .HasColumnName("TYPE")
            .IsRequired();

        builder.Property(p => p.IdealTempMin)
            .HasColumnName("IDEAL_TEMP_MIN");

        builder.Property(p => p.IdealTempMax)
            .HasColumnName("IDEAL_TEMP_MAX");

        builder.Property(p => p.Light)
            .HasColumnName("LIGHT")
            .HasMaxLength(100);

        builder.Property(p => p.WateringFrequency)
            .HasColumnName("WATERING_FREQUENCY");

        builder.Property(p => p.IdealMoistureMin)
            .HasColumnName("IDEAL_MOISTURE_MIN");

        builder.Property(p => p.IdealMoistureMax)
            .HasColumnName("IDEAL_MOISTURE_MAX");

        builder.Property(p => p.Notes)
            .HasColumnName("NOTES")
            .HasMaxLength(500);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .IsRequired();
    }
}

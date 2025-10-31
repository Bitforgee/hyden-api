using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Infrastructure.Configurations;

public class PlantConfiguration : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.ToTable("PLANTS");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("PLANT_ID");

        builder.Property(p => p.Name)
            .HasColumnName("NAME")
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(p => p.RegistrationDate)
            .HasColumnName("REGISTRATION_DATE")
            .IsRequired();

        builder.Property(p => p.SmartPotId)
            .HasColumnName("SMART_POT_ID")
            .IsRequired();

        builder.Property(p => p.PlantSpecificationId)
            .HasColumnName("PLANT_SPECIFICATION_ID")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .IsRequired();

        builder.HasOne(p => p.SmartPot)
            .WithMany()
            .HasForeignKey(p => p.SmartPotId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.PlantSpecification)
            .WithMany()
            .HasForeignKey(p => p.PlantSpecificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

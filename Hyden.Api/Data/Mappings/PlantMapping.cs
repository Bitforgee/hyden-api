using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class PlantMapping : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.ToTable("PLANTS");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("PLANT_ID")
            .HasColumnType("uuid");

        builder.Property(p => p.Name)
            .HasColumnName("NAME")
            .HasColumnType("character varying(120)")
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(p => p.RegistrationDate)
            .HasColumnName("REGISTRATION_DATE")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(p => p.SmartPotId)
            .HasColumnName("SMART_POT_ID")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(p => p.PlantSpecificationId)
            .HasColumnName("PLANT_SPECIFICATION_ID")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("timestamp with time zone")
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

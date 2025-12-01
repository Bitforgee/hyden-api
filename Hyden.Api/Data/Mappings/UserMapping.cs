using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("USERS");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("USER_ID")
            .HasColumnType("uuid");

        builder.Property(u => u.Name)
            .HasColumnName("NAME")
            .HasColumnType("character varying(200)")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("character varying(255)")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("PASSWORD_HASH")
            .HasColumnType("text");

        builder.Property(u => u.EmailConfirmed)
            .HasColumnName("EMAIL_CONFIRMED")
            .HasColumnType("boolean");

        builder.Property(u => u.ProfilePictureUrl)
            .HasColumnName("PROFILE_PICTURE_URL")
            .HasColumnType("character varying(500)")
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}

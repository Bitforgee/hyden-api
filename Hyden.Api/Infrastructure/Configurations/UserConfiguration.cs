using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("USERS");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("USER_ID");

        builder.Property(u => u.Name)
            .HasColumnName("NAME")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("PASSWORD_HASH");

        builder.Property(u => u.EmailConfirmed)
            .HasColumnName("EMAIL_CONFIRMED");

        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATED_AT")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}

using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hyden.Api.Data.Mappings;

public class VerificationCodeMapping : IEntityTypeConfiguration<VerificationCode>
{
    public void Configure(EntityTypeBuilder<VerificationCode> builder)
    {
        builder.ToTable("VERIFICATION_CODES");

        builder.HasKey(v => new { v.Email, v.Purpose });

        builder.Property(v => v.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("character varying(255)")
            .IsRequired();

        builder.Property(v => v.Code)
            .HasColumnName("CODE")
            .HasColumnType("character varying(12)")
            .IsRequired();

        builder.Property(v => v.Purpose)
            .HasColumnName("PURPOSE")
            .HasColumnType("character varying(30)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(v => v.ExpiresAt)
            .HasColumnName("EXPIRES_AT")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}

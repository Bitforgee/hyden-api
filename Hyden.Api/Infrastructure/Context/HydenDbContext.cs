using Flunt.Notifications;
using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Infrastructure.Context;

public class HydenDbContext(DbContextOptions<HydenDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = null!;
    public DbSet<SmartPot> SmartPots { get; init; } = null!;
    public DbSet<PlantSpec> PlantSpecs { get; init; } = null!;
    public DbSet<Plant> Plants { get; init; } = null!;
    public DbSet<IrrigationHistory> IrrigationHistories { get; init; } = null!;
    public DbSet<UserNotification> UserNotifications { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
            entity.HasIndex(u => u.Email).IsUnique();
        });

        modelBuilder.Entity<SmartPot>(entity =>
        {
            entity.ToTable("SmartPots");
            entity.HasKey(s => s.Id);

        });

        modelBuilder.Entity<PlantSpec>(entity =>
        {
            entity.ToTable("PlantSpecs");
            entity.HasKey(p => p.Id);

        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.ToTable("Plants");
            entity.HasKey(p => p.Id);
        });

        modelBuilder.Entity<IrrigationHistory>(entity =>
        {
            entity.ToTable("IrrigationHistories");
            entity.HasKey(i => i.Id);
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.ToTable("UserNotifications");
            entity.HasKey(u => u.Id);
        });

        modelBuilder.Ignore<Notification>();
    }
}
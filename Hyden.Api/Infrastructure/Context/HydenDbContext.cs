using Flunt.Notifications;
using Hyden.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Infrastructure.Context;

public class HydenDbContext(DbContextOptions<HydenDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = null!;
    public DbSet<SmartPot> SmartPots { get; init; } = null!;
    public DbSet<PlantSpecification> PlantSpecs { get; init; } = null!;
    public DbSet<Plant> Plants { get; init; } = null!;
    public DbSet<IrrigationHistory> IrrigationHistories { get; init; } = null!;
    public DbSet<UserNotification> UserNotifications { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HydenDbContext).Assembly);
        modelBuilder.Ignore<Notification>();
    }
}
using Hyden.Api.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Data;

public class HydenDbContext(DbContextOptions<HydenDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = null!;
    public DbSet<SmartPot> SmartPots { get; init; } = null!;
    public DbSet<PlantSpecification> PlantSpecs { get; init; } = null!;
    public DbSet<Plant> Plants { get; init; } = null!;
    public DbSet<IrrigationHistory> IrrigationHistories { get; init; } = null!;
    public DbSet<UserNotification> UserNotifications { get; init; } = null!;
    public DbSet<VerificationCode> VerificationCodes { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HydenDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
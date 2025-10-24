using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Infrastructure.Context;

public class HydenDbContext : DbContext
{
    public HydenDbContext(DbContextOptions<HydenDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

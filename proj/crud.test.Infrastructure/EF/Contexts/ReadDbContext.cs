using crud.test.Infrastructure.EF.Configurations;
using crud.test.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.test.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<ProductReadModel> ProductReadModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Products");
        var configuration = new ReadConfigs();
        modelBuilder.ApplyConfiguration(configuration);
    }
}
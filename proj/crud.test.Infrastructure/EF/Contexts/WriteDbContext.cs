using crud.test.Domain.Domain;
using crud.test.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace crud.test.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Products");
        var Configuration = new WriteConfigs();
        modelBuilder.ApplyConfiguration<Product>(Configuration);
    }
}
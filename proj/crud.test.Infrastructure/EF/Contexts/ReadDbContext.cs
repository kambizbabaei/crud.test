using crud.test.Infrastructure.EF.Configurations;
using crud.test.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.test.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<ProductReadModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Products");
        var Configuration = new ReadConfigs();
        modelBuilder.ApplyConfiguration<ProductReadModel>(Configuration);
    }
}
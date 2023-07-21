using crud.test.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud.test.Infrastructure.EF.Configurations;

public class ReadConfigs : IEntityTypeConfiguration<ProductReadModel>
{
    public void Configure(EntityTypeBuilder<ProductReadModel> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
    }
}
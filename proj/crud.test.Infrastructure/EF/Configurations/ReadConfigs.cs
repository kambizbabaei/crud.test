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

        builder
            .Property(p => p.Id);

        builder
            .Property(x => x.Name)
            .HasColumnName("ProductName");

        builder
            .Property(x => x.ManufactureEmail)
            .HasColumnName("ManufactureEmail");

        builder
            .Property(x => x.ManufacturePhone)
            .HasColumnName("ManufacturePhone");

        builder
            .Property(x => x.ProduceDate)
            .HasColumnName("ProduceDate");
        builder.Property(typeof(bool), "IsAvailable").HasColumnName("IsAvailable");
        builder.ToTable("Products");
    }
}
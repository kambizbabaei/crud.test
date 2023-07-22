using crud.test.Domain.Domain;
using crud.test.Domain.ValueObjects.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace crud.test.Infrastructure.EF.Configurations;

public class WriteConfigs : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(pl => pl.Id);

        var nameConverter = new ValueConverter<ProductName, string>(pn => pn.ToString(),
            l => new ProductName(l));

        var manufactureEmailConverter = new ValueConverter<Email, string>(pme => pme.ToString(),
            pln => new Email(pln));

        var idConverter = new ValueConverter<ProductId, Guid>(pid => pid.Value,
            pid => new ProductId(pid));

        var productManufactureDate = new ValueConverter<Date, DateTime>(pd => pd.Value,
            pd => new Date(pd));
        if (productManufactureDate == null) throw new ArgumentNullException(nameof(productManufactureDate));

        var phoneConverter = new ValueConverter<Phone, string>(pd => pd.Value,
            pd => new Phone(pd));

        builder
            .Property(p => p.Id)
            .HasConversion(idConverter);

        builder
            .Property(typeof(ProductName), "Name")
            .HasConversion(nameConverter)
            .HasColumnName("ProductName");

        builder
            .Property(typeof(Email), "ManufactureEmail")
            .HasConversion(manufactureEmailConverter)
            .HasColumnName("ManufactureEmail");

        builder
            .Property(typeof(Phone), "ManufacturePhone")
            .HasConversion(phoneConverter)
            .HasColumnName("ManufacturePhone");

        builder
            .Property(typeof(Date), "ProduceDate")
            .HasConversion(productManufactureDate)
            .HasColumnName("ProduceDate");
        builder.Property(typeof(bool), "IsAvailable").HasColumnName("IsAvailable");
        builder.ToTable("Products");
    }
    
}
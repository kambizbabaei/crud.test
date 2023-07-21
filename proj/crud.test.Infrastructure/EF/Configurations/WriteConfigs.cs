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

        var NameConverter = new ValueConverter<ProductName, string>(pn => pn.ToString(),
            l => new ProductName(l));

        var manufactureEmailConverter = new ValueConverter<Email, string>(pme => pme.ToString(),
            pln => new Email(pln));

        var IdConverter = new ValueConverter<ProductId, Guid>(pid => pid.Value,
            pid => new ProductId(pid));

        var ProductManufactureDate = new ValueConverter<Date, DateTime>(pd => pd.Value,
            pd => new Date(pd));

        var PhoneConverter = new ValueConverter<Phone, string>(pd => pd.Value,
            pd => new Phone(pd));

        builder
            .Property(p => p.Id)
            .HasConversion(IdConverter);

        builder
            .Property(typeof(ProductName), "Name")
            .HasConversion(NameConverter)
            .HasColumnName("ProductName");

        builder
            .Property(typeof(Email), "ManufactureEmail")
            .HasConversion(manufactureEmailConverter)
            .HasColumnName("ManufactureEmail");

        builder
            .Property(typeof(Phone), "ManufacturePhone")
            .HasConversion(PhoneConverter)
            .HasColumnName("ManufacturePhone");

        builder
            .Property(typeof(Date), "ProduceDate")
            .HasConversion(ProductManufactureDate)
            .HasColumnName("ProduceDate");

        builder.HasKey(x => x.Id);


        builder.ToTable("Products");
    }
}
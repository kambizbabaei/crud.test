using crud.test.Domain.Domain;

namespace crud.test.Domain.Factories;

public interface IProductFactory
{
    Product Create(bool IsAvailable, string ManufactureEmail, string ManufacturePhone, DateTime ProduceDate,
        string Name);

    Product Create(
        (bool IsAvailable, string ManufactureEmail, string ManufacturePhone, DateTime ProduceDate, string Name)
            ProductData);
}
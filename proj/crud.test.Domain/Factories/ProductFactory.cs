using crud.test.Domain.Domain;

namespace crud.test.Domain.Factories;

public class ProductFactory : IProductFactory
{
    public Product Create(bool IsAvailable, string ManufactureEmail, string ManufacturePhone, DateTime ProduceDate,
        string Name)
    {
        throw new NotImplementedException();
    }

    public Product Create(
        (bool IsAvailable, string ManufactureEmail, string ManufacturePhone, DateTime ProduceDate, string Name)
            ProductData)
    {
        throw new NotImplementedException();
    }
}
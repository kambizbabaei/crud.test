using crud.test.Domain.Domain;

namespace crud.test.Domain.Factories;

public class ProductFactory : IProductFactory
{
    public Product Create(Guid id ,bool IsAvailable, string ManufactureEmail, string ManufacturePhone, DateTime ProduceDate,
        string Name)
    {
        return new Product(id, IsAvailable, ManufactureEmail, ManufacturePhone, ProduceDate, Name);
    }
    
}
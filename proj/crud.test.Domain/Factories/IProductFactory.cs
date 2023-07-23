using crud.test.Domain.Domain;

namespace crud.test.Domain.Factories;

public interface IProductFactory
{
    Product Create(Guid id, bool IsAvailable, string ManufactureEmail, string ManufacturePhone, DateTime ProduceDate,
        string Name);
}
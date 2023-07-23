using crud.test.Abstraction.Factory;
using crud.test.Domain.Domain;
using crud.test.Domain.Factories.Exceptions;

namespace crud.test.Domain.Factories;

public class ProductFactory : EntityFactory<Product>, IProductFactory
{
    public Product Create(Guid id, bool IsAvailable, string ManufactureEmail, string ManufacturePhone,
        DateTime ProduceDate,
        string Name)
    {
        var p = new Product(id, IsAvailable, ManufactureEmail, ManufacturePhone, ProduceDate, Name);
        if (Conditions.Count == 0) return p;

        // if (Conditions.All(x => x.IsConditionMet(p)))
        // {
        //     return p;
        // }
        foreach (var condition in Conditions)
            if (!condition.IsConditionMet(p))
                throw new ManufactureMultipleProductAdditionException();
        //todo: exception
        return p;
    }
}
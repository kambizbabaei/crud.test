using crud.test.Application.Services;
using crud.test.Domain.Domain;

namespace crud.test.Application.Rules;

public class ProductCreationRule : BaseRule<Product>
{
    private readonly IProductReadServices _readServices;

    public ProductCreationRule(IProductReadServices readServices)
    {
        _readServices = readServices;
    }


    public bool IsConditionMet(Product entity)
    {
        var products = _readServices.GetProductsByManufactureEmail(entity.GetEmail()).GetAwaiter().GetResult();
        if (products.Count == 0) return true;

        return products.FirstOrDefault(x => x.ProduceDate == entity.GetProduceDate().Value) is null;
    }
}
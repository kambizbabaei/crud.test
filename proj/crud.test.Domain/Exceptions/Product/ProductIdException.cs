using crud.test.Abstraction.Exceptions;

namespace crud.test.Domain.Exceptions.Product;

public class ProductIdException : ProductException
{
    public ProductIdException() : base("Product Id Can Not Be Empty")
    {
    }
}
using crud.test.Abstraction.Exceptions;

namespace crud.test.Domain.Exceptions.Product;

public class ProductNameEmptyException : ProductException
{
    public ProductNameEmptyException() : base("Product Name Can Not Be Empty")
    {
    }
}
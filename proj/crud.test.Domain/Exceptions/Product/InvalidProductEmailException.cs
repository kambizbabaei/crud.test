using crud.test.Abstraction.Exceptions;

namespace crud.test.Domain.Exceptions.Product;

public class InvalidProductEmailException : ProductException
{
    public InvalidProductEmailException() : base("Product Email Is Invalid")
    {
    }
}
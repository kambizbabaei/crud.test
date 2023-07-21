using crud.test.Abstraction.Exceptions;

namespace crud.test.Domain.Exceptions.Product;

public class EmailEmptyException : ProductException
{
    public EmailEmptyException() : base("Email Cannot Be Empty")
    {
    }
}
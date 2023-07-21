using crud.test.Abstraction.Exceptions;

namespace crud.test.Domain.Exceptions.Product;

public class PhoneEmptyException : ProductException
{
    public PhoneEmptyException() : base("Phone Number Cannot Be Empty")
    {
    }
}
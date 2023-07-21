namespace crud.test.Abstraction.Exceptions;

public abstract class ProductException : Exception
{
    protected ProductException(string message) : base(message)
    {
    }
}
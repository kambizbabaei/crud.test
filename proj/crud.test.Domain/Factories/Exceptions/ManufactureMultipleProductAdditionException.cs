using crud.test.Abstraction.Exceptions;

namespace crud.test.Domain.Factories.Exceptions;

public class ManufactureMultipleProductAdditionException : ProductException
{
    public ManufactureMultipleProductAdditionException() : base("Manufacture Cant register More Than One Item/Day!")
    {
    }
}
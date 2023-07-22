using crud.test.Domain.Exceptions.Product;

namespace crud.test.Domain.ValueObjects.Product;

public record ProductName
{
    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ProductNameEmptyException();
        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator string(ProductName name)
    {
        return name.Value;
    }

    public static implicit operator ProductName(string name)
    {
        return new ProductName(name);
    }

    public override string ToString()
    {
        return new string(Value);
    }
}
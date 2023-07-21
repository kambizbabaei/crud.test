using crud.test.Domain.Exceptions.Product;

namespace crud.test.Domain.ValueObjects.Product;

public record ProductId
{
    public ProductId(Guid value)
    {
        if (value == Guid.Empty) throw new ProductIdException();
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(ProductId id)
    {
        return id.Value;
    }

    public static implicit operator ProductId(Guid id)
    {
        return new ProductId(id);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
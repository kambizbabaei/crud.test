using crud.test.Domain.Exceptions.Product;

namespace crud.test.Domain.ValueObjects.Product;

public record Phone
{
    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new PhoneEmptyException();

        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator string(Phone id)
    {
        return id.Value;
    }

    public static implicit operator Phone(string id)
    {
        return new Phone(id);
    }

    public override string ToString()
    {
        return new string(Value);
    }
}
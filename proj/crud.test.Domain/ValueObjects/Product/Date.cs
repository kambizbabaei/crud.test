using System.Globalization;

namespace test.domain.ValueObjects.Product;

public record Date
{
    public Date(DateTime value)
    {
        Value = value.ToUniversalTime().Date;
    }

    public DateTime Value { get; }

    public static implicit operator DateTime(Date id)
    {
        return id.Value;
    }

    public static implicit operator Date(DateTime id)
    {
        return new Date(id);
    }

    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}
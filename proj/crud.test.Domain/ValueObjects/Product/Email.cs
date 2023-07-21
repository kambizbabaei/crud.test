using System.Text.RegularExpressions;
using crud.test.Domain.Exceptions.Product;

namespace crud.test.Domain.ValueObjects.Product;

public record Email
{
    private const string EmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                        + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<![!#$%&'*+/=?^_`{|}~.])"
                                        + @"(?<![.-])@)(?:[a-z0-9][a-z0-9-]{0,62}[a-z0-9]\.)+"
                                        + @"[a-z0-9][a-z0-9-]{0,62}[a-z0-9])$";

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new EmailEmptyException();
        value = value.Trim();

        if (!IsValidEmail(value)) throw new InvalidProductEmailException();
        Value = value;
    }

    public string Value { get; }

    private static bool IsValidEmail(string address)
    {
        return Regex.IsMatch(address, EmailPattern, RegexOptions.IgnoreCase);
    }

    public static implicit operator string(Email email)
    {
        return email.Value;
    }

    public static implicit operator Email(string id)
    {
        return new Email(id);
    }

    public override string ToString()
    {
        return new string(Value);
    }
}
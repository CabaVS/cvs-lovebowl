using CabaVS.LoveBowl.Domain.Errors;
using CabaVS.LoveBowl.Domain.Primitives;
using CabaVS.LoveBowl.Domain.Shared;

namespace CabaVS.LoveBowl.Domain.ValueObjects;

public sealed class UserName : ValueObject
{
    public const int MinLength = 2;
    public const int MaxLength = 50;
    
    private UserName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<UserName> Create(string name)
    {
        var normalized = name.Trim();
        return normalized.Length switch
        {
            0 => UserErrors.NameEmpty(),
            < MinLength => UserErrors.NameTooShort(normalized),
            > MaxLength => UserErrors.NameTooLong(normalized),
            _ => new UserName(normalized)
        };
    }
}
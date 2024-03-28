using System.Text.RegularExpressions;
using CabaVS.LoveBowl.Domain.Errors;
using CabaVS.LoveBowl.Domain.Primitives;
using CabaVS.LoveBowl.Domain.Shared;

namespace CabaVS.LoveBowl.Domain.ValueObjects;

public sealed class UserEmail : ValueObject
{
    public const int MaxLength = 50;
    
    private UserEmail(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<UserEmail> Create(string email, bool isUnique)
    {
        if (!isUnique) return UserErrors.EmailDuplicate();
        
        var normalized = email.Trim();
        
        var isValid = Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(250));
        if (!isValid) return UserErrors.EmailInvalid();
        
        return normalized.Length switch
        {
            > MaxLength => UserErrors.EmailTooLong(normalized),
            _ => new UserEmail(normalized)
        };
    }
}
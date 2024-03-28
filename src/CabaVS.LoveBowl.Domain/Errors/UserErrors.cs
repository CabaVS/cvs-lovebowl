using CabaVS.LoveBowl.Domain.Shared;
using CabaVS.LoveBowl.Domain.ValueObjects;

namespace CabaVS.LoveBowl.Domain.Errors;

public static class UserErrors
{
    public static Error NameEmpty() => new("User.NameEmpty", "User Name shouldn't be empty.");
    public static Error NameTooShort(string actual) => new("User.NameTooShort", $"User Name length should be greater than {UserName.MinLength} characters, but was {actual.Length} characters.");
    public static Error NameTooLong(string actual) => new("User.NameTooLong", $"User Name length should be lesser than {UserName.MaxLength} characters, but was {actual.Length} characters.");
    public static Error EmailInvalid() => new("User.EmailInvalid", $"User Email invalid.");
    public static Error EmailDuplicate() => new("User.EmailDuplicate", $"User already exist with provided Email.");
    public static Error EmailTooLong(string actual) => new("User.EmailTooLong", $"User Email length should be lesser than {UserEmail.MaxLength} characters, but was {actual.Length} characters.");
}
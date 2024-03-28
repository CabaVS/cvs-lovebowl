using CabaVS.LoveBowl.Domain.Shared;

namespace CabaVS.LoveBowl.Domain.Errors;

public static class CoupleErrors
{
    public static Error Duplicate() => new("Couple.Duplicate", "Couple already exist with provided Users.");
    public static Error SameUser() => new("Couple.SameUser", "Cannot create a Couple with the same User.");
}
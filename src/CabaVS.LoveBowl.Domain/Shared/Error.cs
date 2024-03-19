namespace CabaVS.LoveBowl.Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    
    public static implicit operator Result(Error error) => Result.Failure(error);
}
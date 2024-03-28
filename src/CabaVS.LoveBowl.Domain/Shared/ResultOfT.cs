namespace CabaVS.LoveBowl.Domain.Shared;

public sealed class Result<T> : Result
{
    private Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
    {
        _value = value;
    }

    private readonly T? _value;
    
    public T Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException($"Unable to access '{nameof(Value)}' property on failed Result.");
    
    public static Result<T> Success(T value) => new(true, Error.None, value);
    public new static Result<T> Failure(Error error) => new(false, error, default);
    
    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);
}
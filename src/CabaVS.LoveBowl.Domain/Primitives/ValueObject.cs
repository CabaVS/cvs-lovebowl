namespace CabaVS.LoveBowl.Domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();
    
    public static bool operator ==(ValueObject? first, ValueObject? second)
    {
        return first is not null &&
               first.Equals(second);
    }
    
    public static bool operator !=(ValueObject? first, ValueObject? second)
    {
        return !(first == second);
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && 
               ValuesAreEqual(other);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine) * 47;
    }

    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
}
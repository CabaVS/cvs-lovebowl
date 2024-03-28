using CabaVS.LoveBowl.Domain.Errors;
using CabaVS.LoveBowl.Domain.Primitives;
using CabaVS.LoveBowl.Domain.Shared;

namespace CabaVS.LoveBowl.Domain.Entities;

public sealed class Couple : Entity
{
    private Couple(Guid id, User userA, User userB) : base(id)
    {
        UserA = userA;
        UserB = userB;
    }
    
    public User UserA { get; }
    public User UserB { get; }

    public static Result<Couple> Create(User userA, User userB, bool isUniqueByUsers)
    {
        if (!isUniqueByUsers) return CoupleErrors.Duplicate();
        if (userA == userB) return CoupleErrors.SameUser();

        return new Couple(Guid.NewGuid(), userA, userB);
    }
}
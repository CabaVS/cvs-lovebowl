using CabaVS.LoveBowl.Domain.Entities;
using CabaVS.LoveBowl.Domain.Primitives;
using CabaVS.LoveBowl.Domain.ValueObjects;

namespace CabaVS.LoveBowl.Domain.Events;

public sealed record UserCreatedByPartnerDomainEvent(UserEmail Email, User Partner) : IDomainEvent;
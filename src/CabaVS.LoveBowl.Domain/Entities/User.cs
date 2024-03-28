using CabaVS.LoveBowl.Domain.Events;
using CabaVS.LoveBowl.Domain.Primitives;
using CabaVS.LoveBowl.Domain.Shared;
using CabaVS.LoveBowl.Domain.ValueObjects;

namespace CabaVS.LoveBowl.Domain.Entities;

public sealed class User : Entity
{
    private User(Guid id, UserName name, UserEmail email) : base(id)
    {
        Name = name;
        Email = email;
    }
    
    public UserName Name { get; set; }
    public UserEmail Email { get; }

    public static Result<User> Create(Guid id, string name, (string Email, bool IsEmailUnique) emailDetails)
    {
        var userNameResult = UserName.Create(name);
        if (userNameResult.IsFailure) return userNameResult.Error;

        var userEmailResult = UserEmail.Create(emailDetails.Email, emailDetails.IsEmailUnique);
        if (userEmailResult.IsFailure) return userEmailResult.Error;

        return new User(id, userNameResult.Value, userEmailResult.Value);
    }

    public static Result<User> CreateByPartner(UserEmail email, User partner)
    {
        var user = new User(Guid.NewGuid(), UserName.Create("TEMPORARY_NAME").Value, email);
        
        user.RaiseDomainEvent(new UserCreatedByPartnerDomainEvent(email, partner));
        
        return user;
    }
}
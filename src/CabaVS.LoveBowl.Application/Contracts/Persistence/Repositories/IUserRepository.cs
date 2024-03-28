using CabaVS.LoveBowl.Domain.Entities;
using CabaVS.LoveBowl.Domain.ValueObjects;

namespace CabaVS.LoveBowl.Application.Contracts.Persistence.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(UserEmail email, CancellationToken ct = default);
    Task Add(User user);
}
using CabaVS.LoveBowl.Domain.Entities;

namespace CabaVS.LoveBowl.Application.Contracts.Infrastructure;

public interface ICurrentUserService
{
    Task<User> GetCurrentUser(CancellationToken ct = default);
}
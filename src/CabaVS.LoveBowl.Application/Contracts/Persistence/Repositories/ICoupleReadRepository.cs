namespace CabaVS.LoveBowl.Application.Contracts.Persistence.Repositories;

public interface ICoupleReadRepository
{
    Task<bool> IsCoupleExistByUsers(Guid userA, Guid userB, CancellationToken ct = default);
}
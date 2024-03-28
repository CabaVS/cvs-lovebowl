using CabaVS.LoveBowl.Application.Contracts.Persistence.Repositories;

namespace CabaVS.LoveBowl.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    ICoupleRepository BuildCoupleRepository();
    IUserRepository BuildUserRepository();
    
    Task SaveChanges(CancellationToken ct = default);
}
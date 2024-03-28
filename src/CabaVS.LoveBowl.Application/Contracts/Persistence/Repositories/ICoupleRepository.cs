using CabaVS.LoveBowl.Domain.Entities;

namespace CabaVS.LoveBowl.Application.Contracts.Persistence.Repositories;

public interface ICoupleRepository
{
    Task Add(Couple couple);
}
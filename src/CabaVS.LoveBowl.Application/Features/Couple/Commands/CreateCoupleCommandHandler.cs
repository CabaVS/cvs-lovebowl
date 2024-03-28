using CabaVS.LoveBowl.Application.Contracts.Infrastructure;
using CabaVS.LoveBowl.Application.Contracts.Persistence;
using CabaVS.LoveBowl.Application.Contracts.Persistence.Repositories;
using CabaVS.LoveBowl.Domain.Shared;
using CabaVS.LoveBowl.Domain.ValueObjects;
using MediatR;
using CoupleEntity = CabaVS.LoveBowl.Domain.Entities.Couple;
using UserEntity = CabaVS.LoveBowl.Domain.Entities.User;

namespace CabaVS.LoveBowl.Application.Features.Couple.Commands;

internal sealed class CreateCoupleCommandHandler(
    ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork,
    ICoupleReadRepository coupleReadRepository) : IRequestHandler<CreateCoupleCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateCoupleCommand request, CancellationToken cancellationToken)
    {
        var partnerEmailResult = UserEmail.Create(request.PartnerEmail, true);
        if (partnerEmailResult.IsFailure) return partnerEmailResult.Error;
        
        var currentUser = await currentUserService.GetCurrentUser(cancellationToken);
        var userRepository = unitOfWork.BuildUserRepository();
        bool isCoupleExistByUsers;

        var partner = await userRepository.GetUserByEmail(partnerEmailResult.Value, cancellationToken);
        if (partner is null)
        {
            var partnerResult = UserEntity.CreateByPartner(partnerEmailResult.Value, currentUser);
            if (partnerResult.IsFailure) return partnerResult.Error;

            partner = partnerResult.Value;
            isCoupleExistByUsers = false;

            await userRepository.Add(partner);
        }
        else
        {
            isCoupleExistByUsers = await coupleReadRepository.IsCoupleExistByUsers(
                currentUser.Id, partner.Id, cancellationToken);
        }
        
        var coupleResult = CoupleEntity.Create(currentUser, partner, !isCoupleExistByUsers);
        if (coupleResult.IsFailure) return coupleResult.Error;
        
        var coupleRepository = unitOfWork.BuildCoupleRepository();
        await coupleRepository.Add(coupleResult.Value);

        await unitOfWork.SaveChanges(cancellationToken);

        return coupleResult.Value.Id;
    }
}
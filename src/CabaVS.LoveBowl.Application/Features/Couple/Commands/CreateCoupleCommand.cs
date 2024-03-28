using CabaVS.LoveBowl.Domain.Shared;
using MediatR;

namespace CabaVS.LoveBowl.Application.Features.Couple.Commands;

internal sealed record CreateCoupleCommand(
    string PartnerEmail) : IRequest<Result<Guid>>;
using CabaVS.LoveBowl.Application.Contracts.Infrastructure;
using CabaVS.LoveBowl.Domain.Events;
using MediatR;

namespace CabaVS.LoveBowl.Application.Features.User.Events;

internal sealed class UserCreatedByPartnerDomainEventHandler(
    IEmailService emailService) : INotificationHandler<UserCreatedByPartnerDomainEvent>
{
    public async Task Handle(UserCreatedByPartnerDomainEvent notification, CancellationToken cancellationToken)
    {
        await emailService.SendInvitationEmailToUserCreatedByPartner(
            notification.Email.Value,
            notification.Partner.Email.Value,
            notification.Partner.Name.Value,
            cancellationToken);
    }
}
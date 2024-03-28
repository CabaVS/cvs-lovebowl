namespace CabaVS.LoveBowl.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task SendInvitationEmailToUserCreatedByPartner(string email, string partnerEmail, string partnerName, CancellationToken ct = default);
}
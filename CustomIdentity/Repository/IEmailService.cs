using CustomIdentity.Models;

namespace CustomIdentity.Repository
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message);
    }

}

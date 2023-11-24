using CustomIdentity.Models;

namespace CustomIdentity.Repository
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        //Task SendEmailAsync(Message message);
    }

}

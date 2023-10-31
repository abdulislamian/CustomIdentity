using CustomIdentity.Models;
using System.Net.Mail;

namespace CustomIdentity.Repository
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public SmtpEmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(message.From, "TestName"),
                Subject = message.Subject,
                Body = message.Content,
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(message.To));

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }

}

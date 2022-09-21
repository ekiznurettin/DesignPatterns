using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observer
{
    public class UserObserverSendEmail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();
            var mailMessage = new MailMessage();
            var smtpClient = new SmtpClient("ekiznurettin11@gmail.com");
            mailMessage.From = new MailAddress("yazilimdunyasi52@gmail.com");
            mailMessage.To.Add(new MailAddress("ekiznurettin11@gmail.com"));
            mailMessage.Subject = "Konu";
            mailMessage.Body = "Sitemizin genel kuralları";
            mailMessage.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("ekiznurettin11@gmail.com", "nurettin52");
          //  smtpClient.Send(mailMessage);
            logger.LogInformation("Email gönderildi");
        }
    }
}

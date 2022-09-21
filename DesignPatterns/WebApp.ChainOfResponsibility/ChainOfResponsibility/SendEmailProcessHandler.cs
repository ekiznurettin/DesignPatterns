using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public class SendEmailProcessHandler:ProcessHandler
    {
        private readonly string _fileName;
        private readonly string _to;

        public SendEmailProcessHandler(string fileName, string to)
        {
            _fileName = fileName;
            _to = to;
        }
        public override object handle(object o)
        {
            var zipMemoryStream = o as MemoryStream;
            zipMemoryStream.Position = 0;
           
            var mailMessage = new MailMessage();
            var smtpClient = new SmtpClient("ekiznurettin11@gmail.com");
            mailMessage.From = new MailAddress("yazilimdunyasi52@gmail.com");
            mailMessage.To.Add(new MailAddress(_to));
            mailMessage.Subject = "Konu";
            mailMessage.Body = "Sitemizin genel kuralları";
            Attachment attachment = new Attachment(zipMemoryStream, _fileName, MediaTypeNames.Application.Zip);
            mailMessage.Attachments.Add(attachment);

            mailMessage.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("ekiznurettin11@gmail.com", "nurettin52");
            //  smtpClient.Send(mailMessage);
            return base.handle(null);
        }
    }
}


using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackEnd.AgendamentoVacina.Core.Services
{
    public class EmailServ : IEmailServ
    {
        public EmailSettings _emailSettings { get; }
        
        public EmailServ(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string emailPara, string assunto, string menssagem)
        {
            Execute(emailPara, assunto, menssagem).Wait();
            return Task.FromResult(0);
        }

        private async Task Execute(string emailPara, string assunto, string menssagem)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.UsernameEmail)
            };

            mail.To.Add(new MailAddress(emailPara));

            mail.Subject = assunto;
            mail.Body = menssagem;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
            {
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
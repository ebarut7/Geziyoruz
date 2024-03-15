using Geziyoruz.WebUI.Business.Services;
using Geziyoruz.WebUI.Models;
using System.Net.Mail;
using System.Net;

namespace Geziyoruz.WebUI.Business.Manager
{
    public class MailManager : IMailService
    {
        public bool SendMail(MailVM mailVm)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = mailVm.Subject;
            mail.Body = mailVm.Body;
            mail.From = new MailAddress(mailVm.SendMail);
            mail.IsBodyHtml = true;

            string[] receviers = mailVm.MailTo.Split(';');

            foreach (var item in receviers)
            {
                mail.To.Add(item);
            }

            SmtpClient smtpClient = new SmtpClient()
            {
                Credentials = new NetworkCredential(mailVm.SendMail, mailVm.SendPassword),
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true
            };
            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

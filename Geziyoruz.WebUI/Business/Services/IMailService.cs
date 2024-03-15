using Geziyoruz.WebUI.Models;

namespace Geziyoruz.WebUI.Business.Services
{
    public interface IMailService
    {
        bool SendMail(MailVM mailVm);
    }
}

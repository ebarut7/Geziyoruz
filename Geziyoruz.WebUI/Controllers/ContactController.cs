using Geziyoruz.WebUI.Business.Services;
using Geziyoruz.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geziyoruz.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMailService _mailService;

        public ContactController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Contact(MailVM mailVM) 
        {
            _mailService.SendMail(mailVM);
            return View();
        }

    }
}

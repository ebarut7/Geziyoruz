using Geziyoruz.Business.Abstract;
using Geziyoruz.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geziyoruz.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostService _blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
          
            return View(_blogPostService.GetAllAsync().Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

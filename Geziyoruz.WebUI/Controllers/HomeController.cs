using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;
using Geziyoruz.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geziyoruz.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
          
            return View(_blogPostService.GetAllAsync().Result);
        }

        public async Task<IActionResult> Travels(int id)
        {
           BlogPostDto blogPostDto = await _blogPostService.GetByIdAsync(id);
            return View(blogPostDto);
        }

        public IActionResult BuyTravel() 
        { 
            return View();
        }

        public IActionResult AboutUs()
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

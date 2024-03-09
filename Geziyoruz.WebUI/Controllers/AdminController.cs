using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geziyoruz.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public AdminController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> AddBlogPost(BlogPostAddDto blogPostAddDto) 
        {
            int res = await _blogPostService.AddAsync(blogPostAddDto);
            return res > 0 ? RedirectToAction("Home","Home") : View();
        }
    }
}

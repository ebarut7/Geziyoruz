using Geziyoruz.Business.Abstract;
using Geziyoruz.Business.Concrete;
using Geziyoruz.Entities.Concrete;
using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;
using Geziyoruz.Entities.Concrete.Dtos.PictureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geziyoruz.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IPictureService _pictureService;
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IBlogPostService blogPostService, IPictureService pictureService)
        {
            _blogPostService = blogPostService;
            _pictureService = pictureService;
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> AddBlogPost(BlogPostAddDto blogPostAddDto)
        {
            int res = await _blogPostService.AddAsync(blogPostAddDto);
            return res > 0 ? RedirectToAction("Index","Home") : View();
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetPost()
        {
            List<BlogPostDto> blogPostDtos = await _blogPostService.GetAllAsync();
            return View(blogPostDtos);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePost(int id)
        {
            List<BlogPostDto> blogPostDtos= await _blogPostService.GetAllAsync();
            BlogPostDto getBlogPost=blogPostDtos.FirstOrDefault(x => x.Id == id);
            return View(getBlogPost);
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePost(BlogPostDto blogPostDto)
        {
            var res = await _blogPostService.UpdateAsync(blogPostDto);

            return res > 0 ? RedirectToAction("Panel"): View(blogPostDto);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletePost(int id)
        {
            int res = await _blogPostService.DeleteAsync(id);
            return res > 0 ? RedirectToAction("Panel"): View();
        }

    }
}

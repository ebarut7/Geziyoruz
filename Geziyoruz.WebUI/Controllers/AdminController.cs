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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddBlogPost(BlogPostAddDto blogPostAddDto,PictureAddDto pictureAddDto)
        {

            await _pictureService.Add(pictureAddDto);
            foreach (var item in pictureAddDto.Pictures)
            {
                MemoryStream ms= new MemoryStream();
                item.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();
              string base64string=  Convert.ToBase64String(fileBytes);
                blogPostAddDto.Picture = base64string;
            }
            
           // if attıgın yere git


            int res = await _blogPostService.AddAsync(blogPostAddDto);
            return res > 0 ? RedirectToAction("Index","Home") : View();
        }



    }
}



using AutoMapper;
using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete;
using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;
using Geziyoruz.Entities.Concrete.Dtos.PictureDtos;

namespace Geziyoruz.Business.Concrete
{
    public class BlogPostManager : IBlogPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogPostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BlogPostAddDto blogPostAddDto)
        {
            BlogPost blogPost = new BlogPost();
            List<Picture> picture = new List<Picture>();



            foreach (var item in blogPostAddDto.Pictures)
            {
                if (item.Length > 0)
                {
                    string fileExtension = Path.GetExtension(item.FileName).ToLowerInvariant();
                    if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".gif")
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await item.CopyToAsync(ms);
                            byte[] fileBytes = ms.ToArray();
                            string base64String = Convert.ToBase64String(fileBytes);
                            picture.Add(new Picture() { Image = base64String });
                        }

                    }
                }

            }

            blogPost.Picture = picture;
            blogPost.Title = blogPostAddDto.Title;
            blogPost.Paragraph = blogPostAddDto.Paragraph;




            await _unitOfWork.BlogPostDal.AddAsync(blogPost);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            BlogPost blogPost = await _unitOfWork.BlogPostDal.GetAsync(x => x.Id == id);
            await _unitOfWork.BlogPostDal.DeleteAsync(blogPost);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<BlogPostDto>> GetAllAsync()
        {
            List<BlogPost> blogPosts = await _unitOfWork.BlogPostDal.GetAllAsync();
            List<BlogPostDto> blogPostDtos = new List<BlogPostDto>();
            foreach (var item in blogPosts)
            {
                BlogPostDto blogPostDto = _mapper.Map<BlogPostDto>(item);
                blogPostDto.Picture = (await _unitOfWork.PictureDal.GetAsync(x => x.Id == item.Id)).Image;
                blogPostDtos.Add(blogPostDto);
            }
            return blogPostDtos;
        }

        public async Task<BlogPostDto> GetByIdAsync(int id)
        {
            List<BlogPost> blogPosts = await _unitOfWork.BlogPostDal.GetAllAsync();
            List<BlogPostDto> blogPostDtos = new List<BlogPostDto>();
            foreach (var item in blogPosts)
            {
                BlogPostDto blogPostDto= _mapper.Map<BlogPostDto>(item);
                blogPostDto.Picture = (await _unitOfWork.PictureDal.GetAsync(x => x.Id == item.Id)).Image;
                blogPostDtos.Add(blogPostDto);
            }
           var getBlog= blogPostDtos.FirstOrDefault(x => x.Id == id);




            return getBlog;
        }

        public async Task<int> UpdateAsync(BlogPostDto blogPostDto)
        {
            BlogPost blogPost = new BlogPost();
            List<Picture> picture = new List<Picture>();



            foreach (var item in blogPostDto.Pictures)
            {
                if (item.Length > 0)
                {
                    string fileExtension = Path.GetExtension(item.FileName).ToLowerInvariant();
                    if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".gif")
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await item.CopyToAsync(ms);
                            byte[] fileBytes = ms.ToArray();
                            string base64String = Convert.ToBase64String(fileBytes);
                            picture.Add(new Picture() { Image = base64String });
                        }

                    }
                }

            }

            blogPost.Picture = picture;
            blogPost.Title = blogPostDto.Title;
            blogPost.Paragraph = blogPostDto.Paragraph;
            await _unitOfWork.BlogPostDal.UpdateAsync(blogPost);
            return await _unitOfWork.SaveAsync();
        }
    }
}

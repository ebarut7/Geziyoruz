

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
        private readonly IPictureService _pictureService;

        public BlogPostManager(IUnitOfWork unitOfWork, IMapper mapper, IPictureService pictureService )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pictureService = pictureService;
        }

        public Task<int> AddAsync(BlogPostAddDto blogPostAddDto)
        {
            BlogPost blogPost = new BlogPost();
            Picture picture = new Picture();
            picture.Image = blogPostAddDto.Picture;
            
            blogPost.Picture= picture;
            blogPost.Title = blogPostAddDto.Title;
            blogPost.Paragraph = blogPostAddDto.Paragraph;




            _unitOfWork.BlogPostDal.AddAsync(blogPost);
            return _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            BlogPost blogPost = await _unitOfWork.BlogPostDal.GetAsync(x=>x.Id==id);
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
                blogPostDto.Picture = (await _unitOfWork.PictureDal.GetAsync(x => x.Id == item.Id)) .Image;
                blogPostDtos.Add(blogPostDto);
            }
            return blogPostDtos;
        }

        public async Task<BlogPostDto> GetByIdAsync(int id)
        {
            BlogPost blogPost = await _unitOfWork.BlogPostDal.GetAsync(x=>x.Id==id);
            return _mapper.Map<BlogPostDto>(blogPost);
        }

        public async Task<int> UpdateAsync(BlogPostDto blogPostDto)
        {
            BlogPost blogPost = _mapper.Map<BlogPost>(blogPostDto);
            await _unitOfWork.BlogPostDal.UpdateAsync(blogPost);
            return await _unitOfWork.SaveAsync();
        }
    }
}

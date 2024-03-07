

using AutoMapper;
using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete;
using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;

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

        public Task<int> AddAsync(BlogPostAddDto blogPostAddDto)
        {
            BlogPost blogPost= _mapper.Map<BlogPost>(blogPostAddDto);
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

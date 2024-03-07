using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;

namespace Geziyoruz.Business.Abstract
{
    public interface IBlogPostService
    {
        Task<BlogPostDto> GetByIdAsync(int id);
        Task<List<BlogPostDto>> GetAllAsync();

        Task<int> AddAsync(BlogPostAddDto blogPostAddDto);

        Task<int> DeleteAsync(int id);

        Task<int> UpdateAsync(BlogPostDto blogPostDto);

    }
}

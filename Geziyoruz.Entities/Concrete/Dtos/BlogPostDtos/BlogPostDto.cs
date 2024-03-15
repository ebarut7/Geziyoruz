using Geziyoruz.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos
{
    public class BlogPostDto : IDto
    {
        public BlogPostDto()
        {
            Pictures = new();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public List<IFormFile> Pictures { get; set; }
    }
}

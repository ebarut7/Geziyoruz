using Geziyoruz.Core.Entities;

namespace Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos
{
    public class BlogPostDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
    }
}

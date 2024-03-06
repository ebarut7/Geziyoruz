using Geziyoruz.Core.Entities;

namespace Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos
{
    public class BlogPost : IDto
    {
        public string Title { get; set; }
        public string Paragraph { get; set; }
    }
}

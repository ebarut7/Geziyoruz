using Geziyoruz.Core.Entities;

namespace Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos
{
    public class BlogPostAddDto : IDto
    {
        public string Title { get; set; }
        public string Paragraph { get; set; }

        public string Code { get; set; }
    }
}

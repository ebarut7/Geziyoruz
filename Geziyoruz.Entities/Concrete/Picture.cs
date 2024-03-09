
using Geziyoruz.Core.Entities;
using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete
{
    public class Picture : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

    }
}

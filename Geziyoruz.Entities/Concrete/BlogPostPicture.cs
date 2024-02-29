

namespace Geziyoruz.Entities.Concrete
{
    public class BlogPostPicture
    {
        public BlogPostPicture() 
        {
            Pictures=new List<Picture>();
        }
        public int BlogPostId { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}

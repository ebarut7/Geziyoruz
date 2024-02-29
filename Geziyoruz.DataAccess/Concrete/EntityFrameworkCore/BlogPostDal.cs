
using Geziyoruz.DataAccess.Abstract;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore
{
    public class BlogPostDal : RepositoryBase<BlogPost>, IBlogPostDal
    {
        public BlogPostDal(GeziyoruzContext context) : base(context)
        {

        }
    }
}

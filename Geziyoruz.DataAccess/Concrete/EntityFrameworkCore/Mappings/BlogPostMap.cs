

using Geziyoruz.Core.DataAccess.EntityFrameworkCore.Mappings;
using Geziyoruz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class BlogPostMap : EntityMap<BlogPost>
    {
        public override void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Picture).WithOne(x=>x.BlogPost).HasForeignKey<Picture>(x=>x.Id);
            base.Configure(builder);
        }
    }
}

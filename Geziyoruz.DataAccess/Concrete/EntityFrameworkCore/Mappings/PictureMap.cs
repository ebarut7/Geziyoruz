using Geziyoruz.Core.DataAccess.EntityFrameworkCore.Mappings;
using Geziyoruz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class PictureMap : EntityMap<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.BlogPost).WithOne(x=>x.Picture).HasForeignKey<BlogPost>(x=>x.Id);
            base.Configure(builder);
        }
    }
}

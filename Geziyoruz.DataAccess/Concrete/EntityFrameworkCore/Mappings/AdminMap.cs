

using Geziyoruz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AdminMap : EntityMap<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            base.Configure(builder);
        }
    }
}

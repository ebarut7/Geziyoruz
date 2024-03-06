using Geziyoruz.Core.DataAccess.EntityFrameworkCore.Mappings;
using Geziyoruz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AppUserMap : EntityMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Admin).WithOne(x => x.AppUser).HasForeignKey<Admin>(x => x.Id);
            builder.HasOne(x => x.Customer).WithOne(x => x.AppUser).HasForeignKey<Customer>(x => x.Id);

            base.Configure(builder);
        }
    }
}

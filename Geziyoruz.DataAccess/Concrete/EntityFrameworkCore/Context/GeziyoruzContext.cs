
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using Geziyoruz.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class GeziyoruzContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public GeziyoruzContext(DbContextOptions<GeziyoruzContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AdminMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new BlogPostMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new PictureMap());


            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BlogPost> Blogs { get; set; }
        public DbSet<Picture> Pictures { get; set; }







    }
}

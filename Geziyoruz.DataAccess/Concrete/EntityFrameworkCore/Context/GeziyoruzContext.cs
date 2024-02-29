
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
            //Mapler yazılacak
            //builder.ApplyConfiguration(new Map());




            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BlogPost> Blogs { get; set; }
        public DbSet<Picture> Pictures { get; set; }







    }
}

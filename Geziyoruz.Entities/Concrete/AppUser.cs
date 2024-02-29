using Geziyoruz.Entities.Abstract;
using Microsoft.AspNetCore.Identity;


namespace Geziyoruz.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public AppUser()
        {
            CreateDate = DateTime.Now;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; }
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }

    }
}

using Geziyoruz.Core.Entities;
using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
    }
}

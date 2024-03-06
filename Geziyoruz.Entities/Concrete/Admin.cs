

using Geziyoruz.Core.Entities;
using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete
{
    public class Admin : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
    }
}

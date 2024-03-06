
using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete
{
    public class Picture : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }

    }
}

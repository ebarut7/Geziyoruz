

namespace Geziyoruz.Entities.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
        public DateTime CreateDate { get; }

    }
}



using Geziyoruz.Core.Entities;

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

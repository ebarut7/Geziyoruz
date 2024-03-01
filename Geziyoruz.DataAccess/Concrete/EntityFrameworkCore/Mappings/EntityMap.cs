using Geziyoruz.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class EntityMap<T> : IEntityTypeConfiguration<T> where T : class, IEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

        }

    }
}

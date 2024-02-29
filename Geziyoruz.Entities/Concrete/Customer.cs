using Geziyoruz.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geziyoruz.Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
    }
}

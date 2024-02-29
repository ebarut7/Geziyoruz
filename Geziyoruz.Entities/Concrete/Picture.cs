using Geziyoruz.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geziyoruz.Entities.Concrete
{
    public class Picture : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }

    }
}

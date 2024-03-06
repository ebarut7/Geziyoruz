using Geziyoruz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geziyoruz.Entities.Concrete.Dtos.PictureDtos
{
    public class PictureDto:IDto
    {
        public PictureDto()
        {
            Pictures = new();
        }
        public int BlogPostId { get; set; }
        public List<string> Pictures { get; set; }
    }
}

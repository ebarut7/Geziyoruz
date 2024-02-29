using Geziyoruz.Entities.Abstract;
using Microsoft.AspNetCore.Http;


namespace Geziyoruz.Entities.Concrete.Dtos.PictureDtos
{
    public class PictureAddDto : IDto
    {
        public PictureAddDto()
        {
            Pictures = new();
        }
        public int BlogPostId { get; set; }
        public List<IFormFile> Pictures { get; set; }
    }
}

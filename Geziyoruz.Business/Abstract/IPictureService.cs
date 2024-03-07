using Geziyoruz.Entities.Concrete.Dtos.PictureDtos;


namespace Geziyoruz.Business.Abstract
{
    public interface IPictureService
    {
        Task<bool> Add(PictureAddDto pictureAddDto);
    }
}

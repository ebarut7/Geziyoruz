

using Geziyoruz.Business.Abstract;
using Geziyoruz.Entities.Concrete.Dtos.PictureDtos;
using Geziyoruz.Entities.Concrete;

namespace Geziyoruz.Business.Concrete
{
    public class PictureManager : IPictureService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PictureManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(PictureAddDto pictureAddDto)
        {
            foreach (var item in pictureAddDto.Pictures)
            {
                if (item.Length > 0)
                {
                    // Dosya uzantisini aliyoruz.
                    string fileExtension = Path.GetExtension(item.FileName).ToLowerInvariant();
                    if (!string.IsNullOrEmpty(fileExtension) && IsSupportedFileExtension(fileExtension) && IsWithinFileSizeLimit(item.Length))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await item.CopyToAsync(ms);

                            // MS'deki veriyi byte dizisine ceviriyoruz
                            byte[] fileBytes = ms.ToArray();

                            // Base64 formatina ceviriyoruz
                            string base64String = Convert.ToBase64String(fileBytes);
                            Picture picture = new Picture
                            {
                                Image = base64String                               
                            };
                            await _unitOfWork.PictureDal.AddAsync(picture);
                        }
                    }
                }
            }
            return await _unitOfWork.SaveAsync() > 0;
        }

        // Dosya uzantılarını kontrol ediyoruz
        private bool IsSupportedFileExtension(string fileExtension)
        => fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif";


        // Dosya boyutu bizim soyledigimiz limittemi kontrol ediyoruz
        private bool IsWithinFileSizeLimit(long fileSize)
        {
            long fileSizeLimit = 8 * 1024 * 1024; //8 MB limit verdik
            return fileSize <= fileSizeLimit;
        }
    }
}

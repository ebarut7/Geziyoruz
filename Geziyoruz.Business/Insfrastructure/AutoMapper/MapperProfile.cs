

using AutoMapper;
using Geziyoruz.Entities.Concrete;
using Geziyoruz.Entities.Concrete.Dtos.BlogPostDtos;
using Geziyoruz.Entities.Concrete.Dtos.PictureDtos;
using Geziyoruz.Entities.Concrete.Dtos.UserDtos;

namespace Geziyoruz.Business.Insfrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Admin,AdminDto>().ReverseMap();
            CreateMap<AppUser,AdminRegisterDto>().ReverseMap();
            CreateMap<AppUser, CustomerRegisterDto>().ReverseMap();
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<AppUser,Customer>().ReverseMap();
            CreateMap<AppUser,Admin>().ReverseMap();
            CreateMap<BlogPost,BlogPostAddDto>().ReverseMap();
            CreateMap<BlogPost,BlogPostDto>().ReverseMap();
            CreateMap<Picture,PictureAddDto>().ReverseMap();
            CreateMap<Picture,PictureDto>().ReverseMap();
        }
    }
}

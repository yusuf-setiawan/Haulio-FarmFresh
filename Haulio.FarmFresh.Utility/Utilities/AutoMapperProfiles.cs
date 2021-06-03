using AutoMapper;
using Haulio.FarmFresh.DTO.DTOs;
using Haulio.FarmFresh.Entity.Entities;

namespace Haulio.FarmFresh.Utility
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserToListDTO>().ReverseMap();
                CreateMap<User, UserToAddDTO>().ReverseMap();
                CreateMap<User, UserToAuthDTO>().ReverseMap();
                CreateMap<Product, ProductToListDTO>().ReverseMap();
                CreateMap<Product, ProductToAddDTO>().ReverseMap();
            }
        }
    }

}

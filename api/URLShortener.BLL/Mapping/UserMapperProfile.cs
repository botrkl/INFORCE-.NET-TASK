using AutoMapper;
using URLShortener.BLL.Models;
using URLShortener.BLL.Models.AddModels;
using URLShortener.DAL.Entities;

namespace URLShortener.BLL.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.HashPassword))
                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin));

            CreateMap<AddUserModel, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.HashPassword, opt => opt.MapFrom(src => src.Password));
        }
    }
}

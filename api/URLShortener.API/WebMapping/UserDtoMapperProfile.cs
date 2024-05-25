using AutoMapper;
using URLShortener.API.DTOs;
using URLShortener.BLL.Models.AddModels;

namespace URLShortener.API.WebMapping
{
    public class UserDtoMapperProfile : Profile
    {
        public UserDtoMapperProfile() 
        {
            CreateMap<UserRegisterDto, AddUserModel>();
        }
    }
}

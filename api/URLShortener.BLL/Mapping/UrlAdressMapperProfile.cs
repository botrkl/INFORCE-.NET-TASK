using AutoMapper;
using URLShortener.BLL.Models;
using URLShortener.BLL.Models.AddModels;
using URLShortener.DAL.Entities;

namespace URLShortener.BLL.Mapping
{
    public class UrlAdressMapperProfile : Profile
    {
        public UrlAdressMapperProfile() 
        {
            CreateMap<AddUrlAdressModel, UrlAdress>();
            CreateMap<UrlAdress, UrlAdressModel>();
        }
    }
}

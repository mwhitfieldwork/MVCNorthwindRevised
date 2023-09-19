using AutoMapper;
using NWCodeFirstMVC.Domain.Dto;
using NWCodeFirstMVC.Domain.Models;

namespace NWCodeFirstMVC.Api.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

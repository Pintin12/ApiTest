using ApiTest.Dtos.Items;
using ApiTest.Models;
using AutoMapper;

namespace ApiTest
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, GetItemsDto>();
            CreateMap<AddItemsDto, Item>();
            
        }
    }
}

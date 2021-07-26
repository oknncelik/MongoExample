using AutoMapper;
using Entities;
using Entities.Dtos;

namespace Business.Mapping
{
    public class ApplicationMapingProfile : Profile
    {
        public ApplicationMapingProfile()
        {
            CreateMap<Category,CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryCreate>().ReverseMap();
            CreateMap<Category, CategoryUpdate>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Order, OrderCreate>().ReverseMap();     
            CreateMap<Order, OrderUpdate>().ReverseMap();
        }
    }
}

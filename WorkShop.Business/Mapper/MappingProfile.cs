using AutoMapper;

using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Response;

namespace WorkShop.WebMvc.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
using AutoMapper;
using TTI.Application.Dto;
using TTI.Domain.Entity;

namespace TTI.Application.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<SubCategory, SubCategoryGetDto>().ReverseMap();
            CreateMap<SubCategoryPostDto, SubCategory>();
            CreateMap<Product, ProductPostDto>().ReverseMap();
            CreateMap<Product, ProductGetDto>().ReverseMap();
        }
    }
}

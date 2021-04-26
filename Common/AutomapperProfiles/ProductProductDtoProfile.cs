using AutoMapper;
using Common.Models;
using Common.Models.Dto;

namespace Common.AutomapperProfiles
{
    public class ProductProductDtoProfile : Profile
    {
        public ProductProductDtoProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ContainArticleDto, ContainArticle>();
            CreateMap<ContainArticle, ContainArticleDto>();


        }
    }
}

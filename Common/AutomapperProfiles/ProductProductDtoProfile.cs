using AutoMapper;
using Common.Models;

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

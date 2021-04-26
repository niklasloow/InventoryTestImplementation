using AutoMapper;
using Common.Models;
using Common.Models.Dto;

namespace Common.AutomapperProfiles
{
    public class ArticleInventoryProfile : Profile
    {
        public ArticleInventoryProfile()
        {
            CreateMap<Article, InventoryDto>();
            CreateMap<InventoryDto, Article>();

        }
    }
}

using AutoMapper;
using Common.Models;

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

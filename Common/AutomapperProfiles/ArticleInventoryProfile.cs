using AutoMapper;
using Common.Models;

namespace Common.AutomapperProfiles
{
    public class ArticleInventoryProfile : Profile
    {
        public ArticleInventoryProfile()
        {
            CreateMap<Article, InventoryDto>()
                .ForMember(dest => dest.ArtId, source =>
                    source.MapFrom(src => src.ArtId))
                .ForMember(dest => dest.Stock, source =>
                    source.MapFrom(src => src.Stock))
                .ForMember(dest => dest.Name, source =>
                    source.MapFrom(src => src.Name));

        }
    }
}

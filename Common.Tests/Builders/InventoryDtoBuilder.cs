using System.Collections.Generic;
using Common.Models.Dto;

namespace Common.Tests.Builders
{
    public class InventoryDtoBuilder
    {
        private List<InventoryDto> _articles;
        
        public InventoryDtoBuilder Default()
        {
            _articles = new List<InventoryDto>();
            return this;
        }

        public InventoryDtoBuilder WithArticle(string artId, string stock, string name)
        {
            _articles.Add(new InventoryDto
            {
                ArtId = artId,
                Stock = stock,
                Name = name
            });
            return this;
        }

        public InventoryListDto Build()
        {
            return new InventoryListDto
            {
                Inventory = _articles
            };
        }
    }
}
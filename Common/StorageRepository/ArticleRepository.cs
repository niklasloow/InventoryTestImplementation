using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Common.Models;
using Common.Models.Dto;
using Common.StorageRepository.Interfaces;

namespace Common.StorageRepository
{
    public class ArticleRepository : IStorageRepository<Article>
    {
        private readonly IBaseStorageRepository<InventoryListDto> _repository;
        private readonly IMapper _mapper;

        public ArticleRepository(IBaseStorageRepository<InventoryListDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Article GetById(string id)
        {
            var inventory = _repository.Read();
            var correctArticle = inventory?.Inventory
                .FirstOrDefault(part => part.ArtId.Equals(id));
            var article = _mapper.Map<Article>(correctArticle);
            return article;
        }

        public void Update(Article entity)
        {
            var inventoryPart = _mapper.Map<InventoryDto>(entity);
            var inventory = _repository.Read();
            var index = FindIndexForArticle(entity.ArtId, inventory.Inventory);
            inventory.Inventory[index] = inventoryPart;
            _repository.Update(inventory);
        }

        public IEnumerable<Article> GetAll()
        {
            throw new System.NotImplementedException();
        }

        private static int FindIndexForArticle(string articleId, List<InventoryDto> inventory)
        {
            return inventory.FindIndex(x => x.ArtId.Equals(articleId));
        }
    }
}

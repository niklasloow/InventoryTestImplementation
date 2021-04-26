using System.Data;
using Common.Models;
using Common.StorageRepository;

namespace Common.SellingService
{
    public class StockService : IStockService
    {
        private readonly IStorageRepository<Article> _articleRepository;
        private readonly IStorageRepository<Product> _productRepository;
        
        public StockService(IStorageRepository<Article> articleRepository, 
            IStorageRepository<Product> productRepository)
        {
            _articleRepository = articleRepository;
            _productRepository = productRepository;
        }

        public void DecreaseArticleStockForProduct(string productId)
        {
            var product = _productRepository.GetById(productId);
            
            if (product == null)
                throw new DataException($"Could not find requested product of Id :{productId}");

            foreach (var article in product.ContainArticles)
            {
                DecreaseStock(article.ArtId, article.AmountOf);
            }
        }

        private void DecreaseStock(string artId, int amount) => UpdateArticleStock(artId, -amount);
        
        private void IncreaseStock(string artId, int amount) => UpdateArticleStock(artId, amount);

        private void UpdateArticleStock(string artId, int amount)
        {
            var part = _articleRepository.GetById(artId);
            part.Stock += amount;
            _articleRepository.Update(part);
        }
    }
}

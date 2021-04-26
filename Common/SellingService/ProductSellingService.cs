using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Common.SellingService.Interfaces;
using Common.StorageRepository.Interfaces;

namespace Common.SellingService
{
    public class ProductSellingService : IProductSellingService
    {
        private readonly IStockService _stockService;
        private readonly IStorageRepository<Product> _productRepository;
        private readonly IStorageRepository<Article> _articleRepository;

        public ProductSellingService(IStockService stockService, IStorageRepository<Product> productRepository, IStorageRepository<Article> articleRepository)
        {
            _stockService = stockService;
            _productRepository = productRepository;
            _articleRepository = articleRepository;
        }
        
        public bool CanSellProduct(string productId)
        {
            //For the program to run
            return true;
            //throw new NotImplementedException();
        }

        public void SellProduct(string productId)
        {
            _stockService.DecreaseArticleStockForProduct(productId);
        }

        public IEnumerable<Product> GetAllSellableProduct()
        {
            var products = _productRepository.GetAll();
            return products.Select(CalculateStock);
        }

        //TODO should be in its own service
        private Product CalculateStock(Product product)
        {
            var values = new List<int>();
            foreach (var containArticle in product.ContainArticles)
            {
                var inventoryArticle = _articleRepository.GetById(containArticle.ArtId);
                values.Add(inventoryArticle.Stock / containArticle.AmountOf);
            }
            product.Stock = values.OrderBy(x => x).FirstOrDefault();
            return product;
        }
    }
}

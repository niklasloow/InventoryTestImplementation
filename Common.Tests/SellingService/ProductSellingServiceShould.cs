using System;
using System.Collections.Generic;
using Common.Models;
using Common.StorageRepository;

namespace Common.SellingService
{
    public class ProductSellingServiceShould
    {
        private readonly IStockService _stockService;
        private readonly IStorageRepository<Product> _productRepository;

        public ProductSellingServiceShould()
        {
            //_stockService = stockService;
            //_productRepository = productRepository;
        }
        
        public bool CanSellProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public void SellProduct(string productId)
        {
            _stockService.DecreaseArticleStockForProduct(productId);
        }

        public IEnumerable<Product> GetAllSellableProduct()
        {
            return _productRepository.GetAll();
        }
    }
}

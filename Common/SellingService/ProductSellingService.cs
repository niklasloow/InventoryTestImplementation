using System;
using System.Collections.Generic;
using Common.Models;
using Common.SellingService.Interfaces;
using Common.StorageRepository;
using Common.StorageRepository.Interfaces;

namespace Common.SellingService
{
    public class ProductSellingService : IProductSellingService
    {
        private readonly IStockService _stockService;
        private readonly IStorageRepository<Product> _productRepository;

        public ProductSellingService(IStockService stockService, IStorageRepository<Product> productRepository)
        {
            _stockService = stockService;
            _productRepository = productRepository;
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
            return _productRepository.GetAll();
        }
    }
}

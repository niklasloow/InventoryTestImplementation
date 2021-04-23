using System.Collections.Generic;
using Common.Models;

namespace Common.SellingService
{
    public interface IProductSellingService
    {
        bool CanSellProduct(string productId);
        void SellProduct(string productId);
        IEnumerable<Product> GetAllSellableProduct();
    }
}
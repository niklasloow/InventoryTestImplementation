using Common.Models;

namespace Common.SellingService
{
    public interface IStockService
    {
        void DecreaseArticleStockForProduct(string productId);
    }
}
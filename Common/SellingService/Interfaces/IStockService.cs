namespace Common.SellingService.Interfaces
{
    public interface IStockService
    {
        void DecreaseArticleStockForProduct(string productId);
    }
}
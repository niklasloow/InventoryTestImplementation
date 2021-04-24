using Common.AutomapperProfiles;
using Common.Models;
using Common.SellingService;
using Common.StorageRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class DependencyInjectionCommon
    {
        public static void AddCommonInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBaseStorageRepository<InventoryListDto>, FileStorageBaseRepository<InventoryListDto>>(sp
                => new FileStorageBaseRepository<InventoryListDto>(FileNameConstants.Inventory));

            serviceCollection.AddSingleton<IBaseStorageRepository<ProductListDto>, FileStorageBaseRepository<ProductListDto>>(sp
                => new FileStorageBaseRepository<ProductListDto>(FileNameConstants.Products));

            serviceCollection.AddSingleton<IStorageRepository<Article>, ArticleRepository>();
            serviceCollection.AddSingleton<IStorageRepository<Product>, ProductRepository>();
            serviceCollection.AddSingleton<IProductSellingService, ProductSellingService>();
            serviceCollection.AddSingleton<IStockService, StockService>();

            serviceCollection.AddAutoMapper(typeof(ArticleInventoryProfile));
        }

    }

    public static class FileNameConstants
    {
        public static string Inventory => "inventory";
        public static string Products => "products";
    }
}

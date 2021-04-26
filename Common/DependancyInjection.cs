using Common.AutomapperProfiles;
using Common.Models;
using Common.Models.Dto;
using Common.SellingService;
using Common.SellingService.Interfaces;
using Common.StorageRepository;
using Common.StorageRepository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class DependencyInjectionCommon
    {
        public static void AddCommonInjection(this IServiceCollection serviceCollection, IConfiguration config)
        {
            var basePath = config.GetValue<string>(ConfigurationsConstants.BasePathConfigName);
            serviceCollection.AddSingleton<IBaseStorageRepository<InventoryListDto>, FileStorageBaseRepository<InventoryListDto>>(sp
                => new FileStorageBaseRepository<InventoryListDto>(basePath, ConfigurationsConstants.FileNames.Inventory));

            serviceCollection.AddSingleton<IBaseStorageRepository<ProductListDto>, FileStorageBaseRepository<ProductListDto>>(sp
                => new FileStorageBaseRepository<ProductListDto>(basePath, ConfigurationsConstants.FileNames.Products));

            serviceCollection.AddSingleton<IStorageRepository<Article>, ArticleRepository>();
            serviceCollection.AddSingleton<IStorageRepository<Product>, ProductRepository>();
            serviceCollection.AddSingleton<IProductSellingService, ProductSellingService>();
            serviceCollection.AddSingleton<IStockService, StockService>();

            serviceCollection.AddAutoMapper(typeof(ArticleInventoryProfile));
        }

    }

    public static class ConfigurationsConstants
    {
        public static string BasePathConfigName => "FileBasePath";
        public static class FileNames
        {
            public static string Inventory => "inventory";
            public static string Products => "products";
        }
    }
}
